using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.Common.Interfaces
{
    public interface ISecurityRepository
    {
        public Task<Tuple<bool, int>> CheckSecurityExists(string symbol);
    }
}
