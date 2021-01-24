using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alpha.Common.Interfaces;
using Alpha.Common.Models;

namespace Alpha.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly ISecurityRepository securityRepository;
        private readonly IPortfolioRepository portfolioRepository;

        public TransactionService(ITransactionRepository transactionRepository, ISecurityRepository securityRepository, IPortfolioRepository portfolioRepository)
        {
            this.transactionRepository = transactionRepository;
            this.securityRepository = securityRepository;
            this.portfolioRepository = portfolioRepository;
        }

        public async Task<bool> AddTransactionAsync(Transaction transaction)
        {
            // this probably needs to be redesigned to be wrapped in a database transaction
            try
            {
                // check if this security is already in the database
                var securityId = await securityRepository.CheckSecurityExists(transaction.Symbol);

                // if no, add it
                if (!securityId.Item1)
                {
                    // add to db
                }

                // add the transaction
                var success = await transactionRepository.AddTransactionAsync(transaction, securityId.Item2);

                // is this holding already in the portfolio?
                var holdingId = await portfolioRepository.CheckIfHoldingInPortfolio();

                // if not, add
                if (!holdingId.Item1)
                {
                    // add to db
                    await portfolioRepository.AddPortfolioHolding();
                }
                else
                {
                    // if yes, update
                    await portfolioRepository.UpdatePortfolioHolding();
                }

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Transaction>> GetTransactionsAsync()
        {
            return await transactionRepository.GetTransactionsAsync();
        }

        public async Task<bool> DeleteTransactionAsync()
        {
            return await transactionRepository.DeleteTransactionAsync();
        }
    }
}
