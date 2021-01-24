using System;
using System.Collections.Generic;
using System.Text;
using Alpha.Common.Interfaces;
using Alpha.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Alpha.Infrastructure
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<ISecurityRepository, SecurityRepository>();
            services.AddTransient<IPortfolioRepository, PortfolioRepository>();

            return services;
        }
    }
}
