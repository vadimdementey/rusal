using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Interfaces
{
   public interface IAccount : IUser
    {
        string LoginName { get; }
        Guid Password { get; }

    }
}
