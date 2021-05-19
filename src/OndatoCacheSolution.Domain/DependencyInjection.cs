using Microsoft.Extensions.DependencyInjection;
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
        public static void ConfigureDomainService(this IServiceCollection services)
        {
            services.AddSingleton<CacheService>();
        }
    }
}
