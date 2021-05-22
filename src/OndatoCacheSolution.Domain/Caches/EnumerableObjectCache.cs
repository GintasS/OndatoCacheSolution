using OndatoCacheSolution.Domain.Caches.Base;
using OndatoCacheSolution.Domain.Models;
using System;
using System.Collections.Generic;

namespace OndatoCacheSolution.Domain.Caches
{
    public class EnumerableObjectCache<TKey, TValue> : GenericCache<TKey, TValue> where TValue : IEnumerable<object>
    {
        public override void Set(TKey key, TValue value, TimeSpan expiresAfter)
        {
            Cache[key] = new CacheItem<TValue>(value, expiresAfter);
        }
    }
}
