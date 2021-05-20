using Microsoft.Extensions.DependencyInjection;
using OndatoCacheSolution.Domain.Factories;
using OndatoCacheSolution.Domain.Mappings;
using OndatoCacheSolution.Domain.Services;

namespace OndatoCacheSolution.Domain
{
    public static class DependencyInjection
    {
        public static void ConfigureDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<CacheService>();

            services.AddSingleton<CacheItemFactory>();

            services.AddAutoMapper(typeof(MappingsProfile));
        }
    }
}
