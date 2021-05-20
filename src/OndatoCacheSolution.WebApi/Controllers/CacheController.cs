using Microsoft.AspNetCore.Mvc;
using OndatoCacheSolution.Domain.Caches;
using OndatoCacheSolution.Domain.Dtos;
using OndatoCacheSolution.Domain.Exceptions;
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

        [HttpGet("{key}")]
        public IActionResult Get(string key)
        {
            try
            {
                var value = _cacheService.Get(key);
                return Ok(value);
            }
            catch (CacheException ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpDelete("{key}")]
        public IActionResult Remove(string key)
        {
            _cacheService.Remove(key);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Append(CreateListCacheItemDto dto)
        {
            _cacheService.Append(dto);

            return NoContent();
        }
    }
}
