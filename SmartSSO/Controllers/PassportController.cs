using System;
using System.Web.Mvc;
using SmartSSO.Entities;
using SmartSSO.Extendsions;
using SmartSSO.Models;
using SmartSSO.Services;
using SmartSSO.Services.Impl;

namespace SmartSSO.Controllers
{
    /// <summary>
    ///  公钥：AppKey
    ///  私钥：AppSecret
    ///  会话：SessionKey
    /// </summary>
    public class PassportController : Controller
    {
        private readonly IAppInfoService _appInfoService = new AppInfoService();
        private readonly IAppUserService _appUserService = new AppUserService();
        private readonly IUserAuthSessionService _authSessionService = new UserAuthSessionService();
        private readonly IUserAuthOperateService _userAuthOperateService = new UserAuthOperateService();

        private const string AppInfo = "AppInfo";
        private const string SessionKey = "SessionKey";
        private const string SessionUserName = "SessionUserName";

        //默认登录界面
        public ActionResult Index(string appKey = "", string username = "")
        {
            TempData[AppInfo] = _appInfoService.Get(appKey);

            var viewModel = new PassportLoginRequest
            {
                AppKey = appKey,
                UserName = username
            };

            return View(viewModel);
        }

        //授权登录
        [HttpPost]
        public ActionResult Index(PassportLoginRequest model)
        {
            //获取应用信息
            var appInfo = _appInfoService.Get(model.AppKey);
            if (appInfo == null)
            {
                //应用不存在
                return View(model);
            }

            TempData[AppInfo] = appInfo;

            if (ModelState.IsValid == false)
            {
                //实体验证失败
                return View(model);
            }

            //过滤字段无效字符
            model.Trim();

            //获取用户信息
            var userInfo = _appUserService.Get(model.UserName);
            if (userInfo == null)
            {
                //用户不存在
                return View(model);
            }

            if (userInfo.UserPwd != model.Password.ToMd5())
            {
                //密码不正确
                return View(model);
            }

            //获取当前未到期的Session
            var currentSession = _authSessionService.ExistsByValid(appInfo.AppKey, userInfo.UserName);
            if (currentSession == null)
            {
                //构建Session
                currentSession = new UserAuthSession
                {
                    AppKey = appInfo.AppKey,
                    CreateTime = DateTime.Now,
                    InvalidTime = DateTime.Now.AddYears(1),
                    IpAddress = Request.UserHostAddress,
                    SessionKey = Guid.NewGuid().ToString().ToMd5(),
                    UserName = userInfo.UserName
                };

                //创建Session
                _authSessionService.Create(currentSession);
            }
            else
            {
                //延长有效期，默认一年
                _authSessionService.ExtendValid(currentSession.SessionKey);
            }

            //记录用户授权日志
            _userAuthOperateService.Create(new UserAuthOperate
            {
                CreateTime = DateTime.Now,
                IpAddress = Request.UserHostAddress,
                Remark = string.Format("{0} 登录 {1} 授权成功", currentSession.UserName, appInfo.Title),
                SessionKey = currentSession.SessionKey
            });

            var redirectUrl = string.Format("{0}?SessionKey={1}&SessionUserName={2}",
                appInfo.ReturnUrl, 
                currentSession.SessionKey, 
                userInfo.UserName);

            //跳转默认回调页面
            return Redirect(redirectUrl);
        }
    }
}