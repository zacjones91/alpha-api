using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.Infrastructure.Framework
{
    public interface IDbConnectionFactory
    {
        public IDbConnection GetDbConnection();
    }
}
