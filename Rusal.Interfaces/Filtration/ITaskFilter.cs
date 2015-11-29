using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Interfaces.Filtration
{
    public interface ITaskFilter
    {
        DateTime? StartCreatedDate { get;  }
        DateTime? EndCreatedDate   { get;  }
        int? PriorityCode { get;  }
        string SearchText { get;  }   

        int PageIndex { get; }
    }
}
