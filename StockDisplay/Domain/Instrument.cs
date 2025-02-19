namespace StockDisplay.Domain
{
    public class Instrument
    {
        public DateTime AddedOn { get; set; }
        public string CurrencyCode { get; set; } = string.Empty;
        public string Isin { get; set; } = string.Empty;
        public decimal? MaxOpenQuantity { get; set; }
        public decimal? MinTradeQuantity { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public string Ticker { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int WorkingScheduleId { get; set; }
    }
}
