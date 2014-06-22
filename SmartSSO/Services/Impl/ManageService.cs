// 
// Copyright (c) 2014,SmartBooks
// All rights reserved.
// 
// 文件名称：ManageService.cs
// 项目名称：WebManage
// 摘      要：简要描述本文件的内容
// 
// 当前版本：1.0
// 作      者：ya wang
// 完成日期：2014年05月14日
// 

using System.Linq;
using SmartSSO.Services.Util;

namespace SmartSSO.Services.Impl
{
    public sealed class ManageService : ServiceContext, IManageService
    {
        public bool Login(string username, string password)
        {
            return DbContext.ManageUser.FirstOrDefault(p => p.UserName == username && p.UserPwd == password) != null;
        }

        public void Logout(string username)
        {
            //记录用户注销日志
        }
    }
}