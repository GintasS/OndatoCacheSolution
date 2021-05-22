using Microsoft.Extensions.Options;
using OndatoCacheSolution.Domain.Exceptions.Base;
using OndatoCacheSolution.Domain.Models;
using OndatoCacheSolution.Domain.Settings;
using System;
using System.Collections.Generic;

namespace OndatoCacheSolution.Domain.Caches.Base
{
    public class GenericCache<TKey, TValue> 
    {
        protected readonly Dictionary<TKey, CacheItem<TValue>> _cache = new Dictionary<TKey, CacheItem<TValue>>();

        public virtual void Set(TKey key, TValue value, TimeSpan expiresAfter)
        {
            _cache[key] = new CacheItem<TValue>(value, expiresAfter);
        }

        public void Set(TKey key, CacheItem<TValue> cacheItem)
        {
            _cache[key] = cacheItem;
        }

        public void Remove(TKey key)
        {
            _cache.Remove(key);
        }

        public TValue Get(TKey key)
        {
            if (!_cache.ContainsKey(key))
            {
                throw new CacheException($"{key} was not found in the cache");
            }

            var cached = _cache[key];
            if (DateTimeOffset.Now - cached.LastRefreshed >= cached.ExpiresAfter)
            {
                _cache.Remove(key);
                throw new CacheException($"{key} was not found in the cache");
            }

            //refreshing Expiry
            cached.LastRefreshed = DateTimeOffset.Now;
            return cached.Value;
        }
    }
}
