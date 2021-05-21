using OndatoCacheSolution.Domain.Exceptions.Base;
using OndatoCacheSolution.Domain.Models;
using System;
using System.Collections.Generic;

namespace OndatoCacheSolution.Domain.Caches.Base
{
    public class GenericCache<TKey, TValue> where TValue : List<Object>
    {
        protected readonly Dictionary<TKey, CacheItem<TValue>> _cache = new Dictionary<TKey, CacheItem<TValue>>();

        public void Set(TKey key, TValue value, TimeSpan expiresAfter)
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
            if (DateTimeOffset.Now - cached.Created >= cached.ExpiresAfter)
            {
                _cache.Remove(key);
                throw new CacheException($"{key} was not found in the cache");
            }
            return cached.Value;
        }
    }
}
