using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OndatoCacheSolution.Domain.Models
{
    public class CacheItem<T>
    {
        CacheItem()
        {

        }

        public CacheItem(T value, TimeSpan expiresAfter)
        {
            Value = value;
            ExpiresAfter = expiresAfter;
        }
        public T Value { get; init; }
        internal DateTimeOffset Created { get; } = DateTimeOffset.Now;
        public TimeSpan ExpiresAfter { get; init; }
    }
}
