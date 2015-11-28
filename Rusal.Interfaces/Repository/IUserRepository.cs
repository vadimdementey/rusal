using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Interfaces.Repository
{
    interface IUserRepository
    {

        IEnumerable<IUser> GetUsers();
        IUser Login(string userName, Guid password);
        void UpdateUser(IUser user);
        IUser RegisterUser(string userName, Guid password);
    }
}
