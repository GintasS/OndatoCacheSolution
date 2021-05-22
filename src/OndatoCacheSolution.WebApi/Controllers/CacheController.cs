using Microsoft.AspNetCore.Mvc;
using OndatoCacheSolution.WebApi.Controllers.Base;
using System.Collections.Generic;

namespace OndatoCacheSolution.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CacheController : CacheControllerBase<string, List<object>>
    {
        private readonly IEnumerableObjectCacheService<string, List<object>> _cacheService;
        public CacheController(IEnumerableObjectCacheService<string, List<object>> cacheService) : base(cacheService)
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
