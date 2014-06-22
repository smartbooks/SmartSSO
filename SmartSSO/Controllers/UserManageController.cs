using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using SmartSSO.Entities;
using SmartSSO.Extendsions;
using SmartSSO.Filters;
using SmartSSO.Helpers;
using SmartSSO.Models;
using SmartSSO.Services;

namespace SmartSSO.Controllers
{
    [UserAuthorization]
    public class UserManageController : Controller
    {
        #region 私有字段

        private readonly IUserManageService _userManageService = UnityHelper.Instance.Unity.Resolve<IUserManageService>();

        #endregion

        #region action method

        public ActionResult Index()
        {
            return View(_userManageService.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateModelState]
        public ActionResult Create(UserCreateRequest model)
        {
            var userPwdHash = model.Password.ToMd5();

            if (!_userManageService.ExistsUser(model.UserName))
            {
                _userManageService.Create(new ManageUser
                {
                    UserName = model.UserName,
                    UserPwd = userPwdHash,
                    Nick = model.Nick,
                    CreateTime = DateTime.Now
                });

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("_error", "登录账号已存在");

            return View();
        }

        public ActionResult Delete(string username = "")
        {
            if (username.Length > 0)
            {
                _userManageService.Delete(username);
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}