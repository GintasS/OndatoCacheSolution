using Microsoft.AspNetCore.Mvc;
using OndatoCacheSolution.Domain.Dtos;
using OndatoCacheSolution.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OndatoCacheSolution.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CacheController : ControllerBase
    {
        private readonly CacheService _cacheService;

        public CacheController(CacheService cacheService)
        {
            _cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
        }

        [HttpPost]
        public IActionResult Create(CreateCacheItemDto cacheItemDto)
        {
            _cacheService.Create(cacheItemDto.Key, cacheItemDto.Values, cacheItemDto.Offset ?? TimeSpan.FromDays(1));

            return Ok();
        }

        [HttpGet]
        public IActionResult Get(string key)
        {
            var value = _cacheService.Get(key);
            return Ok(value);
        }
    }
}
