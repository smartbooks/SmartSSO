// 
// Copyright (c) 2014,SmartBooks
// All rights reserved.
// 
// 文件名称：ControllerExtendsions.cs
// 项目名称：WY.DC
// 摘      要：简要描述本文件的内容
// 
// 当前版本：1.0
// 作      者：ya wang
// 完成日期：2014年05月05日
// 

using System.Web.Mvc;
using SmartSSO.Filters;

namespace SmartSSO.Extendsions
{
    public static class ControllerExtendsions
    {
        public static string GetCookieUserName(this Controller controller)
        {
            var username = string.Empty;

            if (controller.Request.Cookies[UserAuthorizationAttribute.CookieUserName] != null)
            {
                username = controller.Request.Cookies[UserAuthorizationAttribute.CookieUserName].Value;
            }

            return username;
        }
    }
}