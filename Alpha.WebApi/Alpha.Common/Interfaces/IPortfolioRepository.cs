using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alpha.Common.DTOs;

namespace Alpha.Common.Interfaces
{
    public interface IPortfolioRepository
    {
        public Task<bool> AddPortfolioPosition(PortfolioPositionDto position);
        public Task<bool> DeletePortfolioPosition(int positionId);
        public Task<bool> UpdatePortfolioPosition(PortfolioPositionDto position, string action, int holdingId);
        public Task<int> CheckIfHoldingInPortfolio();
    }
}
