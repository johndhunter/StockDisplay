namespace StockDisplay.Domain
{

    public class Exchange
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Workingschedule[] WorkingSchedules { get; set; } = [];
    }

    public class Workingschedule
    {
        public long Id { get; set; }
        public Timeevent[] TimeEvents { get; set; } = [];
    }

    public class Timeevent
    {
        public DateTime Date { get; set; }
        public string Type { get; set; } = string.Empty; 
    }
}
