using System;
using System.Collections.Generic;
using System.Text;

namespace Alpha.Common.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string PortfolioName { get; set; }
        public List<Position> Positions { get; set; }

        public Portfolio()
        {
            Positions = new List<Position>();
        }
    }
}
