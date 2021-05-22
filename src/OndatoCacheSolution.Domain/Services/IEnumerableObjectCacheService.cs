using OndatoCacheSolution.Domain.Caches;
using OndatoCacheSolution.Domain.Caches.Base;
using OndatoCacheSolution.Domain.Dtos.Base;
using OndatoCacheSolution.Domain.Factories;
using OndatoCacheSolution.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OndatoCacheSolution.Domain.Services
{
    public class IEnumerableObjectCacheService<TKey, TValue> : CacheService<TKey, TValue> where TValue: List<object> 
    {
        private IEnumerableObjectCache<TKey, TValue> _cache;
        public IEnumerableObjectCacheService(
            IEnumerableObjectCache<TKey, TValue> cache, 
            CacheItemFactory<TKey, TValue> cacheItemFactory, 
            CreateCacheItemValidator<TValue> validator) : base(cache, cacheItemFactory, validator)
        {
            _cache = cache;
        }

        public void Append(CreateCacheItemDto<TKey, TValue> itemDto)
        {
            var cacheItem = _cacheItemFactory.Build(itemDto);

            var cachedValue = _cache.Get(itemDto.Key);
            cachedValue.AddRange(cacheItem.Value); //This causes issues
            _cache.Set(itemDto.Key, cachedValue, cacheItem.ExpiresAfter);
        }
    }
}
