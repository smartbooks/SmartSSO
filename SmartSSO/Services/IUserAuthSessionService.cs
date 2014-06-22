using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartSSO.Entities;

namespace SmartSSO.Services
{
    public interface IUserAuthSessionService
    {
        void Create(UserAuthSession model);

        UserAuthSession Get(string sessionKey);

        UserAuthSession ExistsByValid(string appKey, string userName);

        void ExtendValid(string sessionkey);

        bool GetCache(string sessionKey);
    }
}
