using Microsoft.AspNetCore.Mvc;
using OndatoCacheSolution.WebApi.Controllers.Base;
using System.Collections.Generic;
using OndatoCacheSolution.Domain.Dtos.Base;
using OndatoCacheSolution.Domain.Services;

namespace OndatoCacheSolution.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CacheController : CacheControllerBase<string, List<object>>
    {
        private readonly EnumerableObjectCacheService<string, List<object>> _cacheService;
        public CacheController(EnumerableObjectCacheService<string, List<object>> cacheService) : base(cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpPut]
        public IActionResult Append(CreateCacheItemDto<string, List<object>> dto)
        {
            _cacheService.Append(dto);

            return NoContent();
        }
    }
}
