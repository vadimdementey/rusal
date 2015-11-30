using Rusal.Interfaces;
using Rusal.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Security
{
    public class UserContext : IUserContext
    {

        public UserContext(IUserRepository context)
        {
            Logged = context.Login("Admin", "1");
        }

        public IAccount Logged
        {
            get;
           
        }

        public Guid Sid
        {
            get
            {
                return Logged.Id;
            }
        }
    }
}
