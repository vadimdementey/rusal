using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Interfaces
{
   public interface INamedEntity : IEntity
    {
         string Name { get;  }
    }
}
