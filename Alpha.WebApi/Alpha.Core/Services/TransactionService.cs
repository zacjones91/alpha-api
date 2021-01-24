using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alpha.Common.DTOs;
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

        public async Task<bool> AddTransactionAsync(Transaction transaction, int portfolioId)
        {
            // this probably needs to be redesigned to be wrapped in a database transaction
            try
            {
                int securityId;
                int holdingId;

                securityId = await securityRepository.CheckSecurityExists(transaction.Symbol);

                if (securityId is 0)
                {
                    securityId = await securityRepository.AddSecurity(transaction.Symbol, transaction.Description);
                }

                await transactionRepository.AddTransactionAsync(transaction, securityId);

                holdingId = await portfolioRepository.CheckIfHoldingInPortfolio();

                var position = new PortfolioPositionDto()
                {
                    PortfolioId = portfolioId,
                    SecurityId = securityId,
                    Shares = transaction.Quantity
                };

                if (holdingId is 0)
                {
                    await portfolioRepository.AddPortfolioPosition(position);
                }
                else
                {
                    await portfolioRepository.UpdatePortfolioPosition(position, transaction.Action, holdingId);
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
