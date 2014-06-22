using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartSSO.Entities
{
    public class AppInfo
    {
        [MaxLength(32)]
        [Key]
        public string AppKey { get; set; }

        [MaxLength(32)]
        [Required]
        public string AppSecret { get; set; }

        [MaxLength(50)]
        [Required]
        public string Title { get; set; }

        [MaxLength(200)]
        [Required]
        public string Remark { get; set; }

        [MaxLength(1024)]
        [Required]
        public string Icon { get; set; }

        [MaxLength(1024)]
        [Required]
        public string ReturnUrl { get; set; }

        [Required]
        public bool IsEnable { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }
    }
}