using Microsoft.Extensions.DependencyInjection;
using OndatoCacheSolution.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OndatoCacheSolution.Application
{
    public static class DependencyInjection
    {
        public static void ConfigureApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.ConfigureDomainService();
        }
    }
}
