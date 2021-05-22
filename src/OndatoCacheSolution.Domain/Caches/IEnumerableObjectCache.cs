using OndatoCacheSolution.Domain.Caches.Base;
using OndatoCacheSolution.Domain.Models;
using System;
using System.Collections.Generic;

namespace OndatoCacheSolution.Domain.Caches
{
    public class IEnumerableObjectCache<TKey, TValue> : GenericCache<TKey, TValue> where TValue : IEnumerable<object>
    {
        public override void Set(TKey key, TValue value, TimeSpan expiresAfter)
        {
            _cache[key] = new CacheItem<TValue>(value, expiresAfter);
        }
    }
}
