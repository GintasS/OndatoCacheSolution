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
            TimeSpan offsetValue;

            try {
                offsetValue = TimeSpan.Parse(dto.Offset);
            }
            catch(Exception)
            {
                offsetValue = _cacheSettings.DefaultExpirationPeriod; //Set default value;
            }

            return new CacheItem<T>(dto.Value, offsetValue);
        }
    }
}
