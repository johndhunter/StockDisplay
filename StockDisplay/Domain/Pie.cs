namespace StockDisplay.Domain
{
    public class Pie
    {
        public decimal? Cash { get; set; }
        public DividendDetails DividendDetails { get; set; } = new DividendDetails();
        public long Id { get; set; }
        public decimal? Progress { get; set; }
        public Result Result { get; set; } = new Result();
        public string Status { get; set; } = string.Empty;
    }
}
