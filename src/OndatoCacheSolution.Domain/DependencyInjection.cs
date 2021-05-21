using Microsoft.Extensions.DependencyInjection;
using OndatoCacheSolution.Domain.Caches;
using OndatoCacheSolution.Domain.Factories;
using OndatoCacheSolution.Domain.Mappings;
using OndatoCacheSolution.Domain.Services;
using OndatoCacheSolution.Domain.Validators;
using System.Collections.Generic;

namespace OndatoCacheSolution.Domain
{
    public static class DependencyInjection
    {
        public static void ConfigureDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<Cache>();

            services.AddScoped<CacheService>();
            services.AddScoped<CacheItemFactory>();

            services.AddScoped<CreateCacheItemValidator<List<object>>>();

            services.AddAutoMapper(typeof(MappingsProfile));
        }

    }
}
