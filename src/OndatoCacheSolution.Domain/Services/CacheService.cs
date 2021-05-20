using OndatoCacheSolution.Domain.Caches;
using OndatoCacheSolution.Domain.Dtos;
using OndatoCacheSolution.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OndatoCacheSolution.Domain.Services
{
    public class CacheService
    {
        private readonly Cache _cache;
        private readonly CacheItemFactory _cacheItemFactory;

        public CacheService(Cache cache, CacheItemFactory cacheItemFactory)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _cacheItemFactory = cacheItemFactory ?? throw new ArgumentNullException(nameof(cacheItemFactory));
        }

        public IEnumerable<object> Get(string key)
        {
            return _cache.Get(key);
        }

        public void Create(CreateListCacheItemDto itemDto)
        {
            var cacheItem = _cacheItemFactory.Build(itemDto);

            _cache.Set(itemDto.Key, cacheItem);
        }

        public void Append(CreateListCacheItemDto itemDto)
        {
            var cacheItem = _cacheItemFactory.Build(itemDto);

            var cachedValue = _cache.Get(itemDto.Key);
            _cache.Set(itemDto.Key, cachedValue.Concat(cacheItem.Value).ToList(), cacheItem.ExpiresAfter);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}
