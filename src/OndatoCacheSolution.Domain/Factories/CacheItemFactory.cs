using Microsoft.Extensions.Options;
using OndatoCacheSolution.Domain.Dtos.Base;
using OndatoCacheSolution.Domain.Models;
using OndatoCacheSolution.Domain.Settings;
using System;

namespace OndatoCacheSolution.Domain.Factories
{
    public class CacheItemFactory
    {
        private readonly CacheSettings _cacheSettings;

        public CacheItemFactory(IOptions<CacheSettings> cacheSettings)
        {
            _cacheSettings = cacheSettings.Value;
        }

        public CacheItem<T> Build<T>(CreateCacheItemDto<T> dto)
        {
            var offsetValue = !String.IsNullOrEmpty(dto.Offset) ?
                TimeSpan.Parse(dto.Offset) :
                _cacheSettings.DefaultExpirationPeriod;

            return new CacheItem<T>(dto.Value, offsetValue);
        }
    }
}
