using Microsoft.Extensions.DependencyInjection;
using OndatoCacheSolution.Domain.Caches;
using OndatoCacheSolution.Domain.Caches.Base;
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
            services.AddScoped<IEnumerableObjectCacheService<string, List<object>>>();
            services.AddScoped<IEnumerableObjectCache<string, List<object>>>();
            services.ConfigureTypedDomainServices<string, List<object>>();
            services.AddAutoMapper(typeof(MappingsProfile));
        }

        private static void ConfigureTypedDomainServices<TKey, TValue>(this IServiceCollection services)
        {
            
            services.AddSingleton<GenericCache<TKey, TValue>>();
            services.AddScoped<CacheItemFactory<TKey, TValue>>();
            services.AddScoped<CreateCacheItemValidator<TValue>>();
        }

    }
}
