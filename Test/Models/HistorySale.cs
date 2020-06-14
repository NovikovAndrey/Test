using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Project_Requirements.Models
{
    public class HistorySale
    {
        public int Id { get; set; }
        public DateTime DateSale { get; set; }
        public int Sale { get; set; }
        public decimal Price { get; set; }
        public decimal AmountDollars { get; set; }
    }
}
