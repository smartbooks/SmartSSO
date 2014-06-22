using System;
using System.Linq;
using SmartSSO.Entities;
using SmartSSO.Services.Util;

namespace SmartSSO.Services.Impl
{
    public class AppInfoService : ServiceContext, IAppInfoService
    {
        public void Create(AppInfo model)
        {
            DbContext.AppInfo.Add(model);
            DbContext.SaveChanges();
        }

        public AppInfo Get(string appKey)
        {
            return DbContext.AppInfo.FirstOrDefault(p => p.AppKey == appKey);
        }
    }
}