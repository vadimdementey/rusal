using Rusal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Dto
{
    public class PriorityDto : IPriority
    {
        public int Code { get; set; }
        public string Name { get; set; }

        public PriorityDto() { }
        public PriorityDto(IPriority other) : base()
        {
            Code = other.Code;
            Name = other.Name;
        }

    }
}
