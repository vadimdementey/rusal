using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Interfaces.Repository
{
    public interface IUserRepository
    {

        IEnumerable<IUser> GetUsers();
        IUser Login(string userName, string password);
        void UpdateUser(IUser user);
        IUser RegisterUser(string userName, string password);
        IUser SetPassword(Guid userId, string newPassword);

        void RemoveUser(Guid userId);
    }
}
