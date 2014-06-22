using System;
using SmartSSO.Entities;
using SmartSSO.Services.Util;

namespace SmartSSO.Services.Impl
{
    public class UserAuthOperateService : ServiceContext, IUserAuthOperateService
    {
        public void Create(UserAuthOperate model)
        {
            DbContext.UserAuthOperate.Add(model);
            DbContext.SaveChanges();
        }
    }
}