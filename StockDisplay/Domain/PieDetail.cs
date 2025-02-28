namespace T212_Updates.Domain
{
    public class PieDetail
    {
        public PieInstrument[] Instruments { get; set; } = [];
        public PieSettings Settings { get; set; } = new PieSettings();
    }
}
