using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using SmartSSO.Extendsions;
using SmartSSO.Filters;
using SmartSSO.Helpers;
using SmartSSO.Models;
using SmartSSO.Services;


namespace SmartSSO.Controllers
{
    [UserAuthorization]
    public class ProfileController : Controller
    {
        #region private

        private readonly IProfileService _profileService = UnityHelper.Instance.Unity.Resolve<IProfileService>();

        #endregion

        #region action method

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            var httpCookie = Request.Cookies[UserAuthorizationAttribute.CookieUserName];

            if (httpCookie == null) { return View(new ProfileChangePasswordRequest()); }

            var model = new ProfileChangePasswordRequest
            {
                UserName = httpCookie.Value
            };

            return View(model);
        }

        [HttpPost]
        [ValidateModelState]
        public ActionResult ChangePassword(ProfileChangePasswordRequest model)
        {
            model.Trim();

            if (model.CurrentPassword == model.ConfirmPassword)
            {
                ModelState.AddModelError("_error", "新密码与当前密码相同");
                return View(model);
            }

            model.CurrentPassword = model.CurrentPassword.ToMd5();
            model.ConfirmPassword = model.ConfirmPassword.ToMd5();

            var userInfo = _profileService.GetUserInfo(model.UserName);

            if (userInfo != null)
            {
                if (userInfo.UserPwd == model.CurrentPassword)
                {
                    if (_profileService.ChangePassword(model.UserName, model.ConfirmPassword))
                    {
                        return RedirectToAction("LoginOut", "Home");
                    }

                    ModelState.AddModelError("_error", "修改密码失败");
                }
                else
                {
                    ModelState.AddModelError("_error", "当前密码不正确");
                }
            }
            else
            {
                ModelState.AddModelError("_error", string.Format("账号 {0} 不存在", model.UserName));
            }

            return View(model);
        }

        #endregion
    }
}