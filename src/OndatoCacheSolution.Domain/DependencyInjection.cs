using Microsoft.Extensions.DependencyInjection;
using OndatoCacheSolution.Domain.Caches;
using OndatoCacheSolution.Domain.Factories;
using OndatoCacheSolution.Domain.Mappings;
using OndatoCacheSolution.Domain.Services;

namespace OndatoCacheSolution.Domain
{
    public static class DependencyInjection
    {
        public static void ConfigureDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<Caches.Cache>();

            services.AddScoped<Services.CacheService>();
            services.AddScoped<CacheItemFactory>();

            services.AddAutoMapper(typeof(MappingsProfile));
        }
    }
}
