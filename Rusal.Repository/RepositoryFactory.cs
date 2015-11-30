using Rusal.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Repository
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private string           nameOrConnectionString;
        private RepositoryMapper mapper;

        static RepositoryFactory()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            Database.SetInitializer<DbContext>(null);
            Database.SetInitializer<RepositoryContext>(null);

        }


        public RepositoryFactory(string nameOrConnectionString)
        {
            this.nameOrConnectionString = nameOrConnectionString;
            mapper = new RepositoryMapper().UseDefault();
        }

        internal DbContext CreateContext()
        {
            return new RepositoryContext(nameOrConnectionString, mapper);
        }


        public T CreateRepository<T>()
        {

            if (typeof(T) == typeof(IUserRepository))
            {
                return (T)(object)new Repositories.UserRepository(this);
            }

            if (typeof(T) == typeof(ITaskRepository))
            {
                return (T)(object)new Repositories.TaskRepository(this);
            }

            throw new NotSupportedException();

        }
    }
}
