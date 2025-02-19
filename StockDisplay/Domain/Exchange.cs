namespace StockDisplay.Domain
{

    public class Exchange
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Workingschedule[] WorkingSchedules { get; set; } = [];
    }

    public class Workingschedule
    {
        public int Id { get; set; }
        public Timeevent[] TimeEvents { get; set; } = [];
    }

    public class Timeevent
    {
        public DateTime Date { get; set; }
        public string Type { get; set; } = string.Empty; 
    }
}
