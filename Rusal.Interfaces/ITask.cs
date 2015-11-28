using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Interfaces
{
    public interface ITask : INamedEntity
    {
        DateTime CreatedDateTime { get; }
        IUser Author { get;  }
        IUser ToEmployee { get; }
        IPriority Priority { get; }
        string Description { get;  }
        bool Completed { get;  }
    }
}
