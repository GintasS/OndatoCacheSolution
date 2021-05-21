using Microsoft.Extensions.DependencyInjection;
using OndatoCacheSolution.Domain.Caches.Base;
using OndatoCacheSolution.Domain.Factories;
using OndatoCacheSolution.Domain.Mappings;
using OndatoCacheSolution.Domain.Validators;
using System.Collections.Generic;

namespace OndatoCacheSolution.Domain
{
    public static class DependencyInjection
    {
        public static void ConfigureDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<GenericCache<string, List<object>>>();
            services.AddScoped<CacheItemFactory>();

            services.AddScoped<CreateCacheItemValidator<List<object>>>();

            services.AddAutoMapper(typeof(MappingsProfile));
        }

    }
}
