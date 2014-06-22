// 
// Copyright (c) 2014,SmartBooks
// All rights reserved.
// 
// 文件名称：UserManageChangePassword.cs
// 项目名称：WY.DC
// 摘      要：简要描述本文件的内容
// 
// 当前版本：1.0
// 作      者：ya wang
// 完成日期：2014年05月08日
// 

using System.ComponentModel.DataAnnotations;

namespace SmartSSO.Models
{
    public sealed class UserManageChangePassword
    {
        [StringLength(32)]
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9._]+\.[A-Za-z]{2,4}", ErrorMessage = "邮箱地址格式不正确")]
        [Display(Name = "邮箱地址")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [StringLength(32)]
        [Required]
        [Display(Name = "当前密码")]
        [DataType(DataType.Password)]

        public string CurrentPassword { get; set; }

        [StringLength(32)]
        [Required]
        [Display(Name = "新密码")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [StringLength(32)]
        [Required]
        [Display(Name = "重复新密码")]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }
}