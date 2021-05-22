using OndatoCacheSolution.Domain.Caches;
using OndatoCacheSolution.Domain.Dtos.Base;
using OndatoCacheSolution.Domain.Factories;
using OndatoCacheSolution.Domain.Validators;
using System.Collections.Generic;

namespace OndatoCacheSolution.Domain.Services
{
    public class EnumerableObjectCacheService<TKey, TValue> : CacheService<TKey, TValue> where TValue: List<object> 
    {
        private readonly EnumerableObjectCache<TKey, TValue> _cache;
        public EnumerableObjectCacheService(
            EnumerableObjectCache<TKey, TValue> cache, 
            CacheItemFactory<TKey, TValue> cacheItemFactory, 
            CreateCacheItemValidator<TValue> validator) : base(cache, cacheItemFactory, validator)
        {
            _cache = cache;
        }

        public void Append(CreateCacheItemDto<TKey, TValue> itemDto)
        {
            var cacheItem = _cacheItemFactory.Build(itemDto);

            var cachedValue = _cache.Get(itemDto.Key);
            var concatValue = (TValue) cachedValue.Concat(cacheItem.Value); //This causes issues
            _cache.Set(itemDto.Key, concatValue, cacheItem.ExpiresAfter);
        }
    }
}
