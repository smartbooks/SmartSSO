using System;
using System.Web.Http;
using SmartSSO.Entities;
using SmartSSO.Services;
using SmartSSO.Services.Impl;

namespace SmartSSO.ApiControllers
{
    public class PassportController : ApiController
    {
        private readonly IUserAuthSessionService _authSessionService = new UserAuthSessionService();
        private readonly IUserAuthOperateService _userAuthOperateService = new UserAuthOperateService();

        public bool Get(string sessionKey = "", string remark = "")
        {
            if (_authSessionService.GetCache(sessionKey))
            {
                _userAuthOperateService.Create(new UserAuthOperate
                {
                    CreateTime = DateTime.Now,
                    IpAddress = Request.RequestUri.Host,
                    Remark = string.Format("验证成功-{0}", remark),
                    SessionKey = sessionKey
                });

                return true;
            }

            _userAuthOperateService.Create(new UserAuthOperate
            {
                CreateTime = DateTime.Now,
                IpAddress = Request.RequestUri.Host,
                Remark = string.Format("验证失败-{0}", remark),
                SessionKey = sessionKey
            });

            return false;
        }
    }
}