using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Dto
{
    public class NewTaskDto
    {
        public Guid? Task { get; set; }
        public Guid Employee { get; set; }
        public string Name { get; set; }
    }
}
