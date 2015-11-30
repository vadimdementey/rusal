using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Repository
{
    public class RepositoryContext : DbContext 
    {
        private RepositoryMapper mapper;

        public RepositoryContext(string nameOrConnectioString,RepositoryMapper mapper ) : base(nameOrConnectioString)
        {
            this.mapper = mapper;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            mapper.MapTo(modelBuilder);
        }
    }
}
