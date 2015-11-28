using Rusal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Entities
{
    public class Entity : IEntity
    {
        public Guid Id { get; set; }
    }
}
