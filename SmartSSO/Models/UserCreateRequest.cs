using System.ComponentModel.DataAnnotations;

namespace SmartSSO.Models
{
    public class UserCreateRequest
    {
        public UserCreateRequest()
        {
            UserName = string.Empty;
            Password = string.Empty;
        }

        [MaxLength(50)]
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9._]+\.[A-Za-z]{2,4}", ErrorMessage = "电邮邮件格式不正确")]
        [Display(Name = "邮箱地址")]
        public string UserName { get; set; }

        [MinLength(6)]
        [MaxLength(12)]
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "登录密码")]
        public string Password { get; set; }

        [MaxLength(50)]
        [Required]
        [Display(Name = "真实姓名")]
        public string Nick { get; set; }
    }
}