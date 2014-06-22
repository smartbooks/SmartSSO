using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartSSO.Entities;

namespace SmartSSO.Services
{
    public interface IUserAuthOperateService
    {
        void Create(UserAuthOperate model);
    }
}
