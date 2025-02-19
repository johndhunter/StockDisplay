namespace StockDisplay.Domain
{
    // PieDetails (from /pies/{id})
    public class Pie
    {
        public int Cash { get; set; }
        public DividendDetails DividendDetails { get; set; } = new DividendDetails();
        public int Id { get; set; }
        public decimal? Progress { get; set; }
        public Result Result { get; set; } = new Result();
        public string Status { get; set; } = string.Empty;
    }

    public class PieDetail
    {
        public Instrument[] Instruments { get; set; } = [];
        public Settings Settings { get; set; } = new Settings();
    }
}
