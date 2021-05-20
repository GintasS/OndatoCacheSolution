using OndatoCacheSolution.Domain.Exceptions;
using OndatoCacheSolution.Domain.Models;
using System;
using System.Collections.Generic;

namespace OndatoCacheSolution.Domain.Services
{
    public abstract class GenericCacheService<TKey, TValue>
    {
        protected readonly Dictionary<TKey, CacheItem<TValue>> _cache = new Dictionary<TKey, CacheItem<TValue>>();

        public void Create(TKey key, TValue value, TimeSpan expiresAfter)
        {
            _cache[key] = new CacheItem<TValue>(value, expiresAfter);
        }

        public void Create(TKey key, CacheItem<TValue> cacheItem)
        {
            _cache[key] = cacheItem;
        }

        public void Delete(TKey key)
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
                //_cache.Remove(key);
                return default(TValue);
            }
            return cached.Value;
        }
    }
}
