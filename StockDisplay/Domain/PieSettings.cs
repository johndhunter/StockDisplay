using System.Text.Json.Serialization;

namespace T212_Updates.Domain
{
    public class PieSettings
    {
        [JsonConverter(typeof(FlexibleDateTimeOffsetConverter))]
        public DateTimeOffset? CreationDate { get; set; }
        
        [JsonConverter(typeof(FlexibleDateTimeOffsetConverter))]
        public DateTimeOffset? EndDate { get; set; }

        public string DividendCashAction { get; set; } = string.Empty;
        public decimal? Goal { get; set; }
        public string Icon { get; set; } = string.Empty;
        public long Id { get; set; }
        public decimal? InitialInvestment { get; set; }
        public Dictionary<string, decimal?> InstrumentShares { get; set; } = [];
        public string Name { get; set; } = string.Empty;
        public string PublicUrl { get; set; } = string.Empty;
    }
}
