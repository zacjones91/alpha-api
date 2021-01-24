using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Alpha.Common.DTOs;
using Alpha.Common.Interfaces;
using Alpha.Infrastructure.Framework;
using Dapper;

namespace Alpha.Infrastructure.Persistence
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PortfolioRepository(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public async Task<bool> AddPortfolioPosition(PortfolioPositionDto position)
        {
            bool success = false;

            string sql = @"INSERT INTO PortfolioPosition (PortfolioId, SecurityId, Shares) VALUES (@PortfolioId, @SecurityId, @Shares);";

            object p = new
            {
                PortfolioId = position.PortfolioId,
                SecurityId = position.SecurityId,
                Shares = position.Shares
            };

            using var connection = connectionFactory.GetDbConnection();

            var result = await connection.ExecuteAsync(sql: sql, commandType: CommandType.Text, param: p);

            if (result > 0)
            {
                success = true;
            }

            return success;
        }

        public async Task<bool> DeletePortfolioPosition(int positionId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdatePortfolioPosition(PortfolioPositionDto position, string action, int holdingId)
        {
            bool success = false;
            float newShareTotal = 0;

            int existingShares = await GetExistingShares(holdingId);

            if (action == "Buy")
            {
                newShareTotal = existingShares + position.Shares;
            }
            else if (action == "Sell")
            {
                newShareTotal = existingShares - position.Shares;
            }

            string sql = @"UPDATE PortfolioPosition p SET Shares = @Shares WHERE p.Id = @Id;";

            object p = new
            {
                Id = holdingId,
                Shares = newShareTotal
            };

            using var connection = connectionFactory.GetDbConnection();

            var result = await connection.ExecuteAsync(sql: sql, commandType: CommandType.Text, param: p);

            if (result > 0)
            {
                success = true;
            }

            return success;
        }

        private async Task<int> GetExistingShares(int holdingId)
        {
            string sql = @"SELECT p.Shares FROM PortfolioPosition p WHERE p.Id = @HoldingId;";

            object p = new
            {
                HoldingId = holdingId
            };

            using var connection = connectionFactory.GetDbConnection();

            var result = await connection.QuerySingleAsync<int>(sql: sql, commandType: CommandType.Text, param: p);

            return result;
        }

        public async Task<int> CheckIfHoldingInPortfolio()
        {
            throw new NotImplementedException();
        }
    }
}
