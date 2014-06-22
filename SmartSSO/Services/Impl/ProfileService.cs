// 
// Copyright (c) 2014,SmartBooks
// All rights reserved.
// 
// 文件名称：ProfileService.cs
// 项目名称：WebManage
// 摘      要：简要描述本文件的内容
// 
// 当前版本：1.0
// 作      者：ya wang
// 完成日期：2014年05月14日
// 

using System.Data.Entity;
using System.Linq;
using SmartSSO.Entities;
using SmartSSO.Services.Util;

namespace SmartSSO.Services.Impl
{
    public sealed class ProfileService : ServiceContext, IProfileService
    {
        public ManageUser GetUserInfo(string username = "")
        {
            return DbContext.ManageUser.FirstOrDefault(p => p.UserName == username);
        }

        public bool ChangePassword(string username = "", string newPassword = "")
        {
            var userInfo = GetUserInfo(username);

            if (userInfo == null) return false;

            userInfo.UserPwd = newPassword;
            DbContext.Entry(userInfo).State = EntityState.Modified;
            return DbContext.SaveChanges() > 0;
        }
    }
}