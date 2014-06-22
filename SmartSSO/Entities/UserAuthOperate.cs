using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartSSO.Entities
{
    public class UserAuthOperate
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(32)]
        [Required]
        public string SessionKey { get; set; }
        
        [MaxLength(1024)]
        [Required]
        public string Remark { get; set; }

        [MaxLength(15)]
        [Required]
        public string IpAddress { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }
    }
}