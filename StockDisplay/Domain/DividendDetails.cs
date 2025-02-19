namespace StockDisplay.Domain
{
    public class DividendDetails
    {
        public decimal? Gained { get; set; }
        public decimal? InCash { get; set; }
        public decimal? Reinvested { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
