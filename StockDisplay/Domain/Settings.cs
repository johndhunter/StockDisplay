namespace StockDisplay.Domain
{
    public class Settings
    {
        public DateTime CreationDate { get; set; }
        public string DividendCashAction { get; set; } = string.Empty;
        public DateTime EndDate { get; set; }
        public decimal? Goal { get; set; }
        public string Icon { get; set; } = string.Empty;
        public int Id { get; set; }
        public decimal? InitialInvestment { get; set; }
        public Dictionary<string, decimal?> InstrumentShares { get; set; } = [];
        public string Name { get; set; } = string.Empty;
        public string PublicUrl { get; set; } = string.Empty;
    }
}
