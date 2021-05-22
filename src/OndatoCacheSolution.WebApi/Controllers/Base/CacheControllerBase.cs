using Microsoft.AspNetCore.Mvc;
using OndatoCacheSolution.Domain.Dtos.Base;
using OndatoCacheSolution.Domain.Exceptions.Base;
using OndatoCacheSolution.Domain.Services;
using System;
using System.Collections.Generic;

namespace OndatoCacheSolution.WebApi.Controllers.Base
{
    [ApiController]
    [Route("[controller]")]
    public abstract class CacheControllerBase<TKey, TValue> : ControllerBase
    {
        private readonly CacheService<TKey, TValue> _cacheService;

        public CacheControllerBase(CacheService<TKey, TValue> cacheService)
        {
            _cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
        }

        [HttpPost]
        public IActionResult Create(CreateCacheItemDto<TKey, TValue> cacheItemDto)
        {
            try
            {
                _cacheService.Create(cacheItemDto);
            }
            catch (CacheException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpGet("{key}")]
        public IActionResult Get(TKey key)
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
        public IActionResult Remove(TKey key)
        {
            _cacheService.Remove(key);
            return NoContent();
        }
    }
}
