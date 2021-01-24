using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alpha.Common.Models;

namespace Alpha.Common.Interfaces
{
    public interface ISecurityRepository
    {
        public Task<int> CheckSecurityExists(string symbol);
        public Task<int> AddSecurity(string symbol, string name);
    }
}
