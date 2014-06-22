using System.ComponentModel.DataAnnotations;

namespace SmartSSO.Models
{
    public sealed class ProfileChangePasswordRequest
    {
        public ProfileChangePasswordRequest()
        {
            UserName = string.Empty;
            CurrentPassword = string.Empty;
            NewPassword = string.Empty;
            ConfirmPassword = string.Empty;
        }

        [Required]
        [Display(Name = "用户账号")]
        public string UserName { get; set; }

        [StringLength(32)]
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "当前密码")]
        public string CurrentPassword { get; set; }

        [StringLength(32)]
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "新的密码")]
        public string NewPassword { get; set; }

        [Compare("NewPassword")]
        [Display(Name = "确认密码")]
        public string ConfirmPassword { get; set; }

        public void Trim()
        {
            if (!string.IsNullOrEmpty(UserName)) UserName = UserName.Trim();

            if (!string.IsNullOrEmpty(CurrentPassword)) CurrentPassword = CurrentPassword.Trim();

            if (!string.IsNullOrEmpty(NewPassword)) NewPassword = NewPassword.Trim();

            if (!string.IsNullOrEmpty(ConfirmPassword)) ConfirmPassword = ConfirmPassword.Trim();
        }
    }
}