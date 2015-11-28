using Rusal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Dto
{
    public class NamedEntityDto : EntityDto, INamedEntity
    {
        public string Name { get; set; }

        public NamedEntityDto() { }

        public NamedEntityDto(INamedEntity other) : base(other)
        {
            Name = other.Name;
        }
    }
}
