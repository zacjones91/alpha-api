using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Alpha.Common.Interfaces;
using Alpha.Common.Models;
using Alpha.Infrastructure.Framework;
using Dapper;

namespace Alpha.Infrastructure.Persistence
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly IDbConnectionFactory connectionFactory;

        public SecurityRepository(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public async Task<int> CheckSecurityExists(string symbol)
        {
            string sql = @"SELECT s.Id FROM Security s WHERE s.Ticker = @Symbol;";

            object p = new
            {
                Symbol = symbol
            };

            using var connection = connectionFactory.GetDbConnection();

            var result = await connection.QuerySingleAsync<int>(sql: sql, commandType: CommandType.Text, param: p);

            return result;
        }

        public async Task<int> AddSecurity(string symbol, string name)
        {
            string sql = @"INSERT INTO Security (Ticker, SecurityName) VALUES (@Ticker, @SecurityName);";

            object p = new
            {
                Ticker = symbol,
                SecurityName = name
            };

            using var connection = connectionFactory.GetDbConnection();

            var result = await connection.QuerySingleAsync<int>(sql: sql, commandType: CommandType.Text, param: p);

            return result;
        }
    }
}
