using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Interfaces.Filtration
{
    public interface ITaskFilter
    {
        DateTime StartCreatedDate { get; set; }
        DateTime EndCreatedDate   { get; set; }
        int PriorityCode { get; set; }
        string SearchText { get; set; }   
    }
}
