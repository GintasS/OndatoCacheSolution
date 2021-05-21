using OndatoCacheSolution.Domain.Caches;
using OndatoCacheSolution.Domain.Dtos;
using OndatoCacheSolution.Domain.Exceptions;
using OndatoCacheSolution.Domain.Factories;
using OndatoCacheSolution.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OndatoCacheSolution.Domain.Services
{
    public class CacheService
    {
        private readonly Cache _cache;
        private readonly CacheItemFactory _cacheItemFactory;
        private readonly CreateCacheItemValidator<List<object>> _validator;

        public CacheService(Cache cache, CacheItemFactory cacheItemFactory, CreateCacheItemValidator<List<object>> validator)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _cacheItemFactory = cacheItemFactory ?? throw new ArgumentNullException(nameof(cacheItemFactory));
            _validator = validator;
        }

        public IEnumerable<object> Get(string key)
        {
            return _cache.Get(key);
        }

        public void Create(CreateListCacheItemDto itemDto)
        {
            var cacheItem = _cacheItemFactory.Build(itemDto);

            var validationResult = _validator.Validate(cacheItem);

            if (!validationResult.IsValid)
            {
                throw new CacheValidationException(validationResult.ToString());
            }


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
