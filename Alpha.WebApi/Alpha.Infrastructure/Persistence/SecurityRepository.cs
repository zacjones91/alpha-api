using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alpha.Common.Interfaces;
using Alpha.Common.Models;

namespace Alpha.Infrastructure.Persistence
{
    public class SecurityRepository : ISecurityRepository
    {
        public Task<int> AddSecurity(Security security)
        {
            throw new NotImplementedException();
        }

        public Task<int> CheckSecurityExists(string symbol)
        {
            throw new NotImplementedException();
        }
    }
}
