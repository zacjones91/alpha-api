using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alpha.Common.Interfaces;

namespace Alpha.Infrastructure.Persistence
{
    public class SecurityRepository : ISecurityRepository
    {
        public Task<Tuple<bool, int>> CheckSecurityExists(string symbol)
        {
            throw new NotImplementedException();
        }
    }
}
