using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using OndatoCacheSolution.Domain.Dtos;
using OndatoCacheSolution.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace OndatoCacheSolution.IntegrationTests
{
    public class CacheControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly Fixture _fixture = new Fixture();

        public CacheControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        [Fact]
        public async Task Create_CreatingCacheItem_GetsTheItem()
        {
            var client = _factory.CreateClient();

            var dto = _fixture.Build<CreateListCacheItemDto>()
                .With(c => c.Value, _fixture.CreateMany<object>().ToList()).Create();

            var response = await client.PostAsJsonAsync("/Cache", dto);
            response.EnsureSuccessStatusCode();

            response = await client.GetAsync($"/Cache/{dto.Key}");
            response.EnsureSuccessStatusCode();

            var receivedStringValue = await response.Content.ReadAsStringAsync();
            var receivedValue = JsonConvert.DeserializeObject<List<object>>(receivedStringValue);

            dto.Value.Count().Should().Be(receivedValue.Count());
        }

        [Fact]
        public async Task Create_GivenExistingKey_ValueGetsOverwritten()
        {
            var client = _factory.CreateClient();
            var key = "key";

            var dto = _fixture.Build<CreateListCacheItemDto>()
                .With(c => c.Key, key)
                .With(c => c.Value, _fixture.CreateMany<object>(3).ToList()
                ).Create();

            var response = await client.PostAsJsonAsync("/Cache", dto);
            response.EnsureSuccessStatusCode();

            var newDto = _fixture.Build<CreateListCacheItemDto>()
               .With(c => c.Key, key)
               .With(c => c.Value, _fixture.CreateMany<object>(5).ToList()
               ).Create();

            response = await client.GetAsync($"/Cache/{newDto.Key}");
            response.EnsureSuccessStatusCode();

            var receivedStringValue = await response.Content.ReadAsStringAsync();
            var receivedValue = JsonConvert.DeserializeObject<List<object>>(receivedStringValue);

            newDto.Value.Count().Should().Be(receivedValue.Count());
        }

        [Fact]
        public async Task Delete_DeletingCreatedItem_ItemGetsDeleted()
        {
            var client = _factory.CreateClient();

            var dto = _fixture.Build<CreateListCacheItemDto>()
                .With(c => c.Value, _fixture.CreateMany<object>().ToList()).Create();

            var response = await client.PostAsJsonAsync("/Cache", dto);
            response.EnsureSuccessStatusCode();

            await client.DeleteAsync($"/Cache/{dto.Key}");

            response = await client.GetAsync($"/Cache/{dto.Key}");
            response.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task Put_GivenNewItem_DataGetsAppended()
        {
            var client = _factory.CreateClient();

            var dto = _fixture.Build<CreateListCacheItemDto>()
                .With(c => c.Value, _fixture.CreateMany<object>().ToList()).Create();

            var response = await client.PostAsJsonAsync("/Cache", dto);
            response.EnsureSuccessStatusCode();

            response = await client.PutAsJsonAsync("/Cache", dto);
            response.EnsureSuccessStatusCode();

            response = await client.GetAsync($"/Cache/{dto.Key}");
            response.EnsureSuccessStatusCode();

            var receivedStringValue = await response.Content.ReadAsStringAsync();
            var receivedValue = JsonConvert.DeserializeObject<List<object>>(receivedStringValue);

            (dto.Value.Count() * 2).Should().Be(receivedValue.Count());
        }
    }
}
