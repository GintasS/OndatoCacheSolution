using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OndatoCacheSolution.Domain;
using OndatoCacheSolution.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
