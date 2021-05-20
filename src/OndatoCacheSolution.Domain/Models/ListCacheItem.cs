using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OndatoCacheSolution.Domain.Models
{
    public class ListCacheItem : CacheItem<List<object>>
    {
        public ListCacheItem(List<object> value, TimeSpan expiresAfter) 
            : base(value, expiresAfter)
        {

        }
    }
}
