using Rusal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Entities
{
    public class UserEntity : NamedEntity,IUser
    {
    
        public string LoginName { get; set; }
        public Guid Password { get; set; }
        
    }
}
