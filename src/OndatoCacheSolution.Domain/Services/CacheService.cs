using AutoMapper;
using OndatoCacheSolution.Domain.Dtos;
using OndatoCacheSolution.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OndatoCacheSolution.Domain.Services
{
    public class CacheService : GenericCacheService<string, List<object>>
    {
        private readonly IMapper _mapper;

        public CacheService(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void Append(string key, List<object> value, TimeSpan expiresAfter)
        {
            var cachedValue = Get(key);
            Create(key, cachedValue.Concat(value).ToList(), expiresAfter);
        }

        public void Create(CreateCacheItemDto itemDto)
        {
            var item = _mapper.Map<ListCacheItem>(itemDto);
            _cache[itemDto.Key] = item;
        }
    }
}
