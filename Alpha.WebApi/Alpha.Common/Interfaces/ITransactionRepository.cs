using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alpha.Common.Models;

namespace Alpha.Common.Interfaces
{
    public interface ITransactionRepository
    {
        public Task<bool> AddTransactionAsync(Transaction transaction, int symbolId);
        public Task<List<Transaction>> GetTransactionsAsync(int portfolioId);
        public Task<bool> DeleteTransactionAsync(int transactionId);
    }
}
