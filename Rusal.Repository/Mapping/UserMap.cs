using Rusal.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Repository.Mapping
{
    public class UserMap : EntityTypeConfiguration<UserEntity>
    {
        public UserMap()
        {
            ToTable("Users");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("UserId");
            Property(x => x.Name     ).HasMaxLength(50).HasColumnName("UserName");
            Property(x => x.LoginName).HasMaxLength(50).HasColumnName("UserLoginName");
            Property(x => x.Password).HasColumnName("UserPasswordHash");
        }
    }
}
