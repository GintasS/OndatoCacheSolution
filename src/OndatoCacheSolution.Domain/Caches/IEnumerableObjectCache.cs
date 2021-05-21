using OndatoCacheSolution.Domain.Caches.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OndatoCacheSolution.Domain.Caches
{
    public class IEnumerableObjectCache<TKey, TValue> : GenericCache<TKey, TValue> where TValue : IEnumerable<object>
    {
    }
}
