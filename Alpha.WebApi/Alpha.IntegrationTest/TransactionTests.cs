using System;
using Alpha.Common.Interfaces;
using Alpha.Common.Models;
using Alpha.Core.Services;
using Alpha.IntegrationTest.Framework;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Alpha.IntegrationTest
{
    public class TransactionTests
    {
        [Fact]
        public async void AddTransactionAsync()
        {
            // arrange
            var serviceProvider = ServiceCreator.CreateServiceCollection();
            var transactionRepo = serviceProvider.GetService<ITransactionRepository>();
            var securityRepo = serviceProvider.GetService<ISecurityRepository>();
            var portfolioRepo = serviceProvider.GetService<IPortfolioRepository>();

            TransactionService transactionService = new TransactionService(transactionRepo, securityRepo, portfolioRepo);

            var sqlExecutor = new SqlExecutor();

            var portfolio = new Portfolio()
            {
                PortfolioName = Guid.NewGuid().ToString().Substring(1, 6)
            };

            // insert portfolio
            string sql = $"INSERT INTO Portfolio (PortfolioName) VALUES ({portfolio.PortfolioName})";
            portfolio.Id = (int) sqlExecutor.ExecuteScalar(sql);

            var transaction = new Transaction()
            {
                Action = "Buy",
                Amount = 200,
                Date = DateTime.UtcNow,
                Description = "test",
                Fees = 0,
                PortfolioId = portfolio.Id,
                Price = 20,
                Quantity = 10,
                Symbol = "HD"
            };

            // act
            var result = await transactionService.AddTransactionAsync(transaction, portfolio.Id);

            // assert
            Assert.True(result);
        }
    }
}
