using Rusal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Dto
{
    public class EntityDto : IEntity
    {
        public Guid Id { get; set; }

        public EntityDto() { }

        public EntityDto(IEntity other)
        {
            Id = other.Id;
        }


    }
}
