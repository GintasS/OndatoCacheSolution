﻿using OndatoCacheSolution.Domain.Caches;
using OndatoCacheSolution.Domain.Dtos.Base;
using OndatoCacheSolution.Domain.Factories;
using OndatoCacheSolution.Domain.Validators;
using System.Collections.Generic;
using System.Linq;

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
            var cacheItem = CacheItemFactory.Build(itemDto);

            var cachedValue = _cache.Get(itemDto.Key);
            cachedValue.AddRange(cacheItem.Value); //This causes issues
            _cache.Set(itemDto.Key, cachedValue, cacheItem.ExpiresAfter);
        }
    }
}
