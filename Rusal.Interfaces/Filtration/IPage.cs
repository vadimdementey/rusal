using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Interfaces.Filtration
{
    public interface IPage<T> : IEnumerable<T>
    {
        int PageIndex { get;  }
        int PageSize { get;  }
        int Pages { get;  }
    }
}
