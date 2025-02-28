namespace T212_Updates.Domain
{

    public class Order
    {
        public DateTime CreationTime { get; set; }
        public decimal? FilledQuantity { get; set; }
        public decimal FilledValue { get; set; }
        public long Id { get; set; }
        public decimal? LimitPrice { get; set; }
        public decimal? Quantity { get; set; }
        public string Status { get; set; } = string.Empty; 
        public decimal? StopPrice { get; set; }
        public string Strategy { get; set; } = string.Empty;
        public string Ticker { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal? Value { get; set; }
    }
}
