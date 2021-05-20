using Microsoft.AspNetCore.Mvc.Testing;
using OndatoCacheSolution.WebApi;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace OndatoCacheSolution.IntegrationTests
{
    public class CacheControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly WebApplicationFactory<Startup> _factory;

        public CacheControllerTests(HttpClient client, WebApplicationFactory<Startup> factory)
        {
          
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task Create_CreatingCacheItem_GetsTheItem()
        {
            var 
        }
    }
}
