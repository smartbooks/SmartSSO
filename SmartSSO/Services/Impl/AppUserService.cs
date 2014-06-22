using System;
using System.Linq;
using SmartSSO.Entities;
using SmartSSO.Services.Util;

namespace SmartSSO.Services.Impl
{
    public class AppUserService : ServiceContext, IAppUserService
    {
        public AppUser Get(string username = "")
        {
            return DbContext.AppUser.FirstOrDefault(p => p.UserName == username);
        }
    }
}