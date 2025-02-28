namespace T212_Updates.Domain
{
    public class PieInstrument
    {
        public decimal? CurrentShare { get; set; }
        public decimal? ExpectedShare { get; set; }
        public Issue[] Issues { get; set; } = [];
        public decimal? OwnedQuantity { get; set; }
        public Result Result { get; set; } = new Result();
        public string Ticker { get; set; } = string.Empty;
    }
}
