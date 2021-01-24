using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Alpha.Infrastructure;

namespace Alpha.IntegrationTest.Framework
{
    public static class ServiceCreator
    {
        public static ServiceProvider CreateServiceCollection()
        {
            var services = new ServiceCollection();
            services.AddInfrastructure();

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
