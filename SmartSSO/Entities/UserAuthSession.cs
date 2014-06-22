using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartSSO.Entities
{
    public class UserAuthSession
    {
        [Key]
        [MaxLength(32)]
        [Required]
        public string SessionKey { get; set; }

        [MaxLength(32)]
        [Required]
        public string AppKey { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }
        
        [MaxLength(15)]
        [Required]
        public string IpAddress { get; set; }

        [Required]
        public DateTime InvalidTime { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }
    }
}