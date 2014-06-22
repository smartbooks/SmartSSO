using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using SmartSSO.Cache;
using SmartSSO.Entities;
using SmartSSO.Services.Models;
using SmartSSO.Services.Util;

namespace SmartSSO.Services.Impl
{
    public class UserAuthSessionService : ServiceContext, IUserAuthSessionService
    {
        public UserAuthSessionService()
        {
            SetCacheInstance(new EnyimMemcachedContext());
        }

        public UserAuthSession ExistsByValid(string appKey, string userName)
        {
            var currentTime = DateTime.Now;
            return DbContext.UserAuthSession.FirstOrDefault(p => p.AppKey == appKey && p.UserName == userName && p.InvalidTime >= currentTime);
        }

        public void ExtendValid(string sessionkey)
        {
            var model = DbContext.UserAuthSession.FirstOrDefault(p => p.SessionKey == sessionkey);
            if (model != null)
            {
                //延长一年
                model.InvalidTime = DateTime.Now.AddYears(1);

                DbContext.Entry(model).State = EntityState.Modified;

                DbContext.SaveChanges();

                //设置缓存
                CacheContext.Set(model.SessionKey, new SessionCacheItem
                {
                    AppKey = model.AppKey,
                    InvalidTime = model.InvalidTime,
                    UserName = model.UserName
                });
            }
        }

        public void Create(UserAuthSession model)
        {
            //添加Session
            DbContext.UserAuthSession.Add(model);
            DbContext.SaveChanges();

            //设置缓存
            CacheContext.Set(model.SessionKey, new SessionCacheItem
            {
                AppKey = model.AppKey,
                InvalidTime = model.InvalidTime,
                UserName = model.UserName
            });
        }

        public UserAuthSession Get(string sessionKey)
        {
            return DbContext.UserAuthSession.FirstOrDefault(p => p.SessionKey == sessionKey);
        }

        public bool GetCache(string sessionKey)
        {
            var sessionCacheItem = CacheContext.Get<SessionCacheItem>(sessionKey);

            if (sessionCacheItem == null) return false;

            if (sessionCacheItem.InvalidTime > DateTime.Now)
            {
                return true;
            }

            //移除无效Session缓存
            CacheContext.Remove(sessionKey);

            return false;
        }
    }
}