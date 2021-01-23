using System;
using System.Collections.Generic;
using System.Text;

namespace Alpha.Common.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Action { get; set; }
        public int SecurityId { get; set; }
        public string Description { get; set; }
        public float Quantity { get; set; }
        public float Price { get; set; }
        public float Fees { get; set; }
        public float Amount { get; set; }
    }
}
