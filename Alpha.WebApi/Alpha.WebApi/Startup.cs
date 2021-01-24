using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Alpha.Common.Interfaces;
using Alpha.Infrastructure;
using Alpha.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Alpha.WebApi.Startup))]

namespace Alpha.WebApi
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder
                .Services
                .AddInfrastructure();
        }
    }
}
