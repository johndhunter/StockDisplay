namespace StockDisplay.Domain
{
    public class Result
    {
        public decimal? PriceAvgInvestedValue { get; set; }
        public decimal? PriceAvgResult { get; set; }
        public decimal? PriceAvgResultCoef { get; set; }
        public decimal? PriceAvgValue { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
