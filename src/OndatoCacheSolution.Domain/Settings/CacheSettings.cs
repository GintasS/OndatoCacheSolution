using OndatoCacheSolution.Domain.Converter;
using System;
using System.Text.Json.Serialization;

namespace OndatoCacheSolution.Domain.Settings
{
    public class CacheSettings
    {
        [JsonConverterAttribute(typeof(TimeSpanConverter))]
        public TimeSpan DefaultExpirationPeriod { get; set; }

        [JsonConverterAttribute(typeof(TimeSpanConverter))]
        public TimeSpan MaxExpirationPeriod { get; set; }

        [JsonConverterAttribute(typeof(TimeSpanConverter))]
        public TimeSpan CleanupInterval { get; set; }
    }
}
