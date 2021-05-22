using OndatoCacheSolution.Domain.Exceptions.Base;
using OndatoCacheSolution.Domain.Models;
using System;
using System.Collections.Generic;

namespace OndatoCacheSolution.Domain.Caches.Base
{
    public class GenericCache<TKey, TValue> 
    {
        protected readonly Dictionary<TKey, CacheItem<TValue>> Cache = new();

        public virtual void Set(TKey key, TValue value, TimeSpan expiresAfter)
        {
            Cache[key] = new CacheItem<TValue>(value, expiresAfter);
        }

        public void Set(TKey key, CacheItem<TValue> cacheItem)
        {
            Cache[key] = cacheItem;
        }

        public void Remove(TKey key)
        {
            Cache.Remove(key);
        }

        public TValue Get(TKey key)
        {
            if (!Cache.ContainsKey(key))
            {
                throw new CacheException($"{key} was not found in the cache");
            }

            var cached = Cache[key];
            if (DateTimeOffset.Now - cached.LastRefreshed >= cached.ExpiresAfter)
            {
                Cache.Remove(key);
                throw new CacheException($"{key} was not found in the cache");
            }

            //refreshing Expiry
            cached.LastRefreshed = DateTimeOffset.Now;
            return cached.Value;
        }
    }
}
