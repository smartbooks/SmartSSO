using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartSSO.Extendsions;
using SmartSSO.Filters;
using SmartSSO.Helpers;
using SmartSSO.Models;
using SmartSSO.Services;
using Microsoft.Practices.Unity;

namespace SmartSSO.Controllers
{
    public class HomeController : Controller
    {
        #region 私有字段

        private readonly IManageService _manageService = UnityHelper.Instance.Unity.Resolve<IManageService>();

        #endregion

        #region index method

        [UserAuthorization]
        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #region 登录操作

        public ActionResult Login()
        {
            return View(new HomeLoginRequest());
        }

        [HttpPost]
        [ValidateModelState]
        public ActionResult Login(HomeLoginRequest model)
        {
            model.Trim();

            if (_manageService.Login(model.UserName, model.Password.ToMd5()))
            {
                Response.Cookies.Add(new HttpCookie(UserAuthorizationAttribute.CookieUserName, model.UserName));
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("_error", "登录密码错误或用户不存在或用户被禁用。");

            return View();
        }

        #endregion

        #region 注销操作

        [UserAuthorization]
        public ActionResult LoginOut()
        {
            if (Request.Cookies[UserAuthorizationAttribute.CookieUserName] != null &&
                !string.IsNullOrWhiteSpace(Request.Cookies[UserAuthorizationAttribute.CookieUserName].Value))
            {
                //退出登录日志记录操作
                _manageService.Logout(Request.Cookies[UserAuthorizationAttribute.CookieUserName].Value);

                Response.Cookies.Add(new HttpCookie(UserAuthorizationAttribute.CookieUserName, string.Empty));
            }

            return RedirectToAction("Login");
        }

        #endregion
    }
}