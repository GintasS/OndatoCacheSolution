using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OndatoCacheSolution.Domain.Services
{
    public class CacheService : GenericCacheService<string, List<object>>
    {
        public void Append(string key, List<object> value, TimeSpan expiresAfter)
        {
            var cachedValue = Get(key);
            Create(key, value.Concat(value).ToList(), expiresAfter);

        }
    }
}
