// 
// Copyright (c) 2014,SmartBooks
// All rights reserved.
// 
// 文件名称：IProfileService.cs
// 项目名称：WY.DC.Service
// 摘      要：简要描述本文件的内容
// 
// 当前版本：1.0
// 作      者：ya wang
// 完成日期：2014年05月09日
// 

using SmartSSO.Entities;

namespace SmartSSO.Services
{
    public interface IProfileService
    {
        ManageUser GetUserInfo(string username = "");

        bool ChangePassword(string username = "", string newPassword = "");
    }
}