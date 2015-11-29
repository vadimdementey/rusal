using Rusal.Interfaces.Filtration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace Rusal.Dto.Filtration
{
    public class PageDto<TDto,TInterface> : IPage<TDto>
    {
        public TDto[] DataSet { get; set; }

       
        public PageDto(IPage<TInterface> other, Func<TInterface,TDto> selector)
        {
            PageIndex = other.PageIndex;
            PageSize  = other.PageSize;
            Pages     = other.Pages;

            DataSet = other.Select(selector).ToArray();
        }

        public int PageIndex { get; set; }
      
        public int Pages { get; set; }
        
        public int PageSize { get; set; }
       
        public IEnumerator<TDto> GetEnumerator()
        {
            return (DataSet as IEnumerable<TDto>).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
