using Rusal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Entities
{
    public class PriorityEntity : IPriority
    {
        public int Code { get; set; }
       
        public string Name { get; set; }
      
    }
}
