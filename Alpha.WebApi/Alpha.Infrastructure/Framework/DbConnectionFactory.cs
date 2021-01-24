using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Alpha.Infrastructure.Framework
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration config;

        public DbConnectionFactory(IConfiguration config)
        {
            this.config = config;
        }

        public IDbConnection GetDbConnection()
        {
            return new SqlConnection(config["ConnectionString"]);
        }
    }
}
