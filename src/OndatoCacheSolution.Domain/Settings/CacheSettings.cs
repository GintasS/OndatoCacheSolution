using OndatoCacheSolution.Domain.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OndatoCacheSolution.Domain.Settings
{
    public class CacheSettings
    {
        [System.Text.Json.Serialization.JsonConverterAttribute(typeof(TimeSpanConverter))]
        public TimeSpan DefaultExpirationPeriod { get; set; }
    }
}
