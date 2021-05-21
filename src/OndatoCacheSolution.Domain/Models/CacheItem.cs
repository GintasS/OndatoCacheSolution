using System;
using System.Collections.Generic;

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
