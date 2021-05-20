using OndatoCacheSolution.Domain.Exceptions;
using OndatoCacheSolution.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OndatoCacheSolution.Domain.Services
{
    public class GenericCacheService<TKey, TValue>
    {
        private readonly Dictionary<TKey, CacheItem<TValue>> _cache = new Dictionary<TKey, CacheItem<TValue>>();

        public void Create(TKey key, TValue value, TimeSpan expiresAfter)
        {
            _cache[key] = new CacheItem<TValue>(value, expiresAfter);
        }

        public void Create(TKey key, CacheItem<TValue> item)
        {
            _cache[key] = item;
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
