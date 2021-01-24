using System;
using System.Collections.Generic;
using System.Text;

namespace Alpha.Common.DTOs
{
    public class PortfolioPositionDto
    {
        public int PortfolioId { get; set; }
        public int SecurityId { get; set; }
        public float Shares { get; set; }
    }
}
