namespace StockDisplay.Domain
{

    public class AccountCash
    {
        public decimal? Blocked { get; set; }
        public decimal? Free { get; set; }
        public decimal? Invested { get; set; }
        public decimal? PieCash { get; set; }
        public decimal? Ppl { get; set; }
        public decimal? Result { get; set; }
        public decimal? Total { get; set; }
    }

    public class AccountMetadata
    {
        public string CurrencyCode{ get; set; } = string.Empty;
        public long Id { get; set; } 
    }

}
