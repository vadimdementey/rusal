using Rusal.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Repository.Mapping
{
    public class PriorityMap : EntityTypeConfiguration<PriorityEntity>
    {
        public PriorityMap()
        {
            ToTable("TaskPriorities");
            HasKey(x => x.Code);
            Property(x => x.Code).HasColumnName("Code");
            Property(x => x.Name).HasMaxLength(50).HasColumnName("Name");
        }
    }
}
