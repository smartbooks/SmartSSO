using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartSSO.Entities;

namespace SmartSSO.Services
{
    public interface IAppUserService
    {
        AppUser Get(string username = "");
    }
}
