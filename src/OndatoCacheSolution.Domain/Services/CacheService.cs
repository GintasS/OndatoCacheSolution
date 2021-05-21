using OndatoCacheSolution.Domain.Caches.Base;
using OndatoCacheSolution.Domain.Dtos.Base;
using OndatoCacheSolution.Domain.Exceptions;
using OndatoCacheSolution.Domain.Factories;
using OndatoCacheSolution.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OndatoCacheSolution.Domain.Services
{
    public class CacheService<TKey, TValue>
    {
        private readonly GenericCache<TKey, TValue> _cache;
        protected readonly CacheItemFactory<TKey, TValue> _cacheItemFactory;
        protected readonly CreateCacheItemValidator<TValue> _validator;

        public CacheService(GenericCache<TKey, TValue> cache, CacheItemFactory<TKey, TValue> cacheItemFactory, CreateCacheItemValidator<TValue> validator)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _cacheItemFactory = cacheItemFactory ?? throw new ArgumentNullException(nameof(cacheItemFactory));
            _validator = validator;
        }

        public TValue Get(TKey key)
        {
            return _cache.Get(key);
        }

        public void Create(CreateCacheItemDto<TKey, TValue> itemDto)
        {
            var cacheItem = _cacheItemFactory.Build(itemDto);

            var validationResult = _validator.Validate(cacheItem);

            if (!validationResult.IsValid)
            {
                throw new CacheValidationException(validationResult.ToString());
            }


            _cache.Set(itemDto.Key, cacheItem);
        }

        public void Remove(TKey key)
        {
            _cache.Remove(key);
        }
    }
}
