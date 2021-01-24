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
                int securityId;
                int holdingId;

                // check if this security is already in the database
                securityId = await securityRepository.CheckSecurityExists(transaction.Symbol);

                // if no, add it
                if (securityId is 0)
                {
                    securityId = await securityRepository.AddSecurity(transaction.Symbol, transaction.Description);
                }

                // add the transaction
                await transactionRepository.AddTransactionAsync(transaction, securityId);

                // is this holding already in the portfolio?
                holdingId = await portfolioRepository.CheckIfHoldingInPortfolio();

                // if not, add, otherwise update
                if (holdingId is 0)
                {
                    await portfolioRepository.AddPortfolioHolding();
                }
                else
                {
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
