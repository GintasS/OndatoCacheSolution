using Microsoft.Extensions.DependencyInjection;
using OndatoCacheSolution.Domain.Factories;
using OndatoCacheSolution.Domain.Mappings;
using OndatoCacheSolution.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OndatoCacheSolution.Domain
{
    public static class DependencyInjection
    {
        public static void ConfigureDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<CacheService>();

            services.AddScoped<CacheItemFactory>();

            services.AddAutoMapper(typeof(MappingsProfile));
        }
    }
}
