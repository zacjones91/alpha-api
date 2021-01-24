using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.Common.Interfaces
{
    public interface IPortfolioRepository
    {
        public Task<bool> AddPortfolioHolding();
        public Task<bool> DeletePortfolioHolding();
        public Task<bool> UpdatePortfolioHolding();
        public Task<Tuple<bool, int>> CheckIfHoldingInPortfolio();
    }
}
