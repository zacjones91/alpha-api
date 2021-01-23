using System;
using System.Collections.Generic;
using System.Text;

namespace Alpha.Common.Models
{
    public class Position
    {
        public int Id { get; set; }
        public int PortfolioId { get; set; }
        public Security Security { get; set; }
        public float CostBasis { get; set; }
        public float Shares { get; set; }
    }
}
