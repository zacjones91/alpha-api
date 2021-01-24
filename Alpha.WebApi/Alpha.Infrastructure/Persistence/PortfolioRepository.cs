using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alpha.Common.Interfaces;

namespace Alpha.Infrastructure.Persistence
{
    public class PortfolioRepository : IPortfolioRepository
    {
        public Task<bool> AddPortfolioHolding()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePortfolioHolding()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePortfolioHolding()
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<bool, int>> CheckIfHoldingInPortfolio()
        {
            throw new NotImplementedException();
        }
    }
}
