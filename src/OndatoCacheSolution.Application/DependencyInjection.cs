using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OndatoCacheSolution.Domain;
using OndatoCacheSolution.Domain.Settings;

namespace OndatoCacheSolution.Application
{
    public static class DependencyInjection
    {
        public static void ConfigureApplication(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.ConfigureDomainServices();

            var cacheSettingSection =
              configuration.GetSection("CacheSettings");

            serviceCollection.Configure<CacheSettings>(cacheSettingSection);

        }
    }
}
