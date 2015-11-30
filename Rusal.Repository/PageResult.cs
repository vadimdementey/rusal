using Rusal.Interfaces.Filtration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace Rusal.Repository
{
    internal class PageResult<TInterface> : IPage<TInterface>
    {
        private List<TInterface> dataSet;

        public int PageIndex { get;  }
       
        public int Pages { get; private set; }

        public int PageSize { get;  }


        internal PageResult(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize  = pageSize<1?10:pageSize;
        }


        public IEnumerator<TInterface> GetEnumerator()
        {
            return dataSet.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public IPage<TInterface> ExecuteWith<TEntity>(IQueryable<TEntity> query) where TEntity : TInterface
        {
            Pages = query.Count() / PageSize;

            if (PageIndex > 0)
            {
                query = query.Take(PageIndex * PageSize);
            }

            dataSet = query
                        .Take(PageSize)
                        .AsEnumerable()
                        .OfType<TInterface>()
                        .ToList();

            return this;
           
        }
    }
}
