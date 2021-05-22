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
        public CacheController(IEnumerableObjectCacheService<string, List<object>> cacheService,
            IEnumerableObjectCacheService<string, List<object>> concreteCacheService) : base(cacheService, concreteCacheService)
        {
        }
    }
}
