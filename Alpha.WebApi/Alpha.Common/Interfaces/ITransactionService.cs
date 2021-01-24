using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alpha.Common.Models;

namespace Alpha.Common.Interfaces
{
    public interface ITransactionService
    {
        public Task<bool> AddTransactionAsync(Transaction transaction, int portfolioId);
        public Task<List<Transaction>> GetTransactionsAsync();
        public Task<bool> DeleteTransactionAsync();
    }
}
