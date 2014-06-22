using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartSSO.Services.Models
{
    [Serializable]
    public class SessionCacheItem
    {
        public string AppKey { get; set; }

        public string UserName { get; set; }

        public DateTime InvalidTime { get; set; }
    }
}