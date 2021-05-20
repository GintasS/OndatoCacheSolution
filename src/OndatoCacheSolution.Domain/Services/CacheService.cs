using OndatoCacheSolution.Domain.Dtos;
using OndatoCacheSolution.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OndatoCacheSolution.Domain.Services
{
    public class CacheService : GenericCacheService<string, List<object>>
    {
        private readonly CacheItemFactory _cacheItemfactory;

        public CacheService(CacheItemFactory cacheItemfactory)
        {
            _cacheItemfactory = cacheItemfactory ?? throw new ArgumentNullException(nameof(cacheItemfactory));
        }

        public void Append(string key, List<object> value, TimeSpan expiresAfter)
        {
            var cachedValue = Get(key);
            Create(key, cachedValue.Concat(value).ToList(), expiresAfter);
        }

        public void Create(CreateListCacheItemDto itemDto)
        {
            var cacheItem = _cacheItemfactory.Build(itemDto);

            Create(itemDto.Key, cacheItem);
        }
    }
}
