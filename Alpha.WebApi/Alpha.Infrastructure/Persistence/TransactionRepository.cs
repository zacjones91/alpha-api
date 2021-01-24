using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpha.Common.Interfaces;
using Alpha.Common.Models;
using Alpha.Infrastructure.Framework;
using Dapper;

namespace Alpha.Infrastructure.Persistence
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IDbConnectionFactory connectionFactory;

        public TransactionRepository(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public async Task<bool> AddTransactionAsync(Transaction transaction, int symbolId)
        {
            bool success = false;

            string sql = @"INSERT INTO Transaction (Date, Action, SecurityId, Description, Quantity, Price, Fees, Amount) VALUES 
                                                    (@Date, @Action, @Description, @Quantity, @Price, @Fees, @Amount)";

            object p = new
            {
                Date = transaction.Date,
                Action = transaction.Action,
                SecurityId = symbolId,
                Description = transaction.Description,
                Quantity = transaction.Quantity,
                Price = transaction.Price,
                Fees = transaction.Fees,
                Amount = transaction.Amount
            };

            using var connection = connectionFactory.GetDbConnection();

            var result = await connection.ExecuteAsync(sql: sql, commandType: CommandType.Text, param: p);

            if (result > 0)
            {
                success = true;
            }

            return success;
        }

        public async Task<List<Transaction>> GetTransactionsAsync(int portfolioId)
        {
            string sql = @"SELECT Date, Action, SecurityId, Description, Quantity, Price, Fees, Amount, PortfolioId FROM Transaction t WHERE t.PortfolioId = @PortfolioId";

            object p = new
            {
                PortfolioId = portfolioId
            };

            using var connection = connectionFactory.GetDbConnection();

            var result = connection.Query<Transaction>(sql: sql, commandType: CommandType.Text, param: p);

            return result.ToList();
        }

        public async Task<bool> DeleteTransactionAsync(int transactionId)
        {
            bool success = false;

            string sql = @"DELETE FROM Transaction t WHERE t.Id = @TransactionId";

            object p = new
            {
                TransactionId = transactionId
            };

            using var connection = connectionFactory.GetDbConnection();

            var result = await connection.ExecuteAsync(sql: sql, commandType: CommandType.Text, param: p);

            if (result != 0)
            {
                success = true;
            }

            return success;
        }
    }
}
