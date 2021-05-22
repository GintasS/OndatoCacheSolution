using OndatoCacheSolution.Domain.Caches.Base;
using OndatoCacheSolution.Domain.Dtos.Base;
using OndatoCacheSolution.Domain.Exceptions;
using OndatoCacheSolution.Domain.Factories;
using OndatoCacheSolution.Domain.Validators;
using System;

namespace OndatoCacheSolution.Domain.Services
{
    public class CacheService<TKey, TValue>
    {
        private readonly GenericCache<TKey, TValue> _cache;
        protected readonly CacheItemFactory<TKey, TValue> CacheItemFactory;
        protected readonly CreateCacheItemValidator<TValue> Validator;

        public CacheService(GenericCache<TKey, TValue> cache, CacheItemFactory<TKey, TValue> cacheItemFactory, CreateCacheItemValidator<TValue> validator)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            CacheItemFactory = cacheItemFactory ?? throw new ArgumentNullException(nameof(cacheItemFactory));
            Validator = validator;
        }

        public TValue Get(TKey key)
        {
            return _cache.Get(key);
        }

        public void Create(CreateCacheItemDto<TKey, TValue> itemDto)
        {
            var cacheItem = CacheItemFactory.Build(itemDto);

            var validationResult = Validator.Validate(cacheItem);

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
