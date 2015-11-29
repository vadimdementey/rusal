using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Repository
{
    public abstract class RepositoryBase : IDisposable
    {
        protected readonly DbContext  Context;

        public RepositoryBase(RepositoryFactory factory)
        {
            Context = factory.CreateContext();
        }


        protected T CreateNew<T>() where T : class
        {
            DbSet<T> dataSet = Context.Set<T>();

            T newEntity = dataSet.Create();
            dataSet.Add(newEntity);

            return newEntity;
        }


        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
