using Rusal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Dto
{
    public class UserDto : NamedEntityDto,IUser
    {
        public UserDto() { }

        public UserDto(IUser other) : base(other) { }

    }
}
