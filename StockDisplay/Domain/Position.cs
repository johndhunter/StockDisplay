using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T212_Updates.Domain
{

    public class Position
    {
        public decimal? AveragePrice { get; set; }
        public decimal? CurrentPrice { get; set; }
        public string Frontend { get; set; } = string.Empty;
        public decimal? FxPpl { get; set; }
        public DateTime InitialFillDate { get; set; }
        public decimal? MaxBuy { get; set; }
        public decimal? MaxSell { get; set; }
        public decimal? PieQuantity { get; set; }
        public decimal? Ppl { get; set; }
        public decimal? Quantity { get; set; }
        public string Ticker { get; set; } = string.Empty;
    }
}
