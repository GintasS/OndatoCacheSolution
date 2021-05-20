using Microsoft.AspNetCore.Mvc;
using OndatoCacheSolution.Domain.Caches;
using OndatoCacheSolution.Domain.Dtos;
using OndatoCacheSolution.Domain.Services;
using System;

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
        public IActionResult Create(CreateListCacheItemDto cacheItemDto)
        {
            _cacheService.Create(cacheItemDto);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get(string key)
        {
            var value = _cacheService.Get(key);
            return Ok(value);
        }

        [HttpDelete]
        public IActionResult Remove(string key)
        {
            _cacheService.Remove(key);
            return NoContent();
        }

        public IActionResult Append(CreateListCacheItemDto dto)
        {
            _cacheService.Append(dto);
        }
    }
}
