namespace T212_Updates.Domain
{

    public class Exchange
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public WorkingSchedule[] WorkingSchedules { get; set; } = [];
    }

    public class WorkingSchedule
    {
        public long Id { get; set; }
        public TimeEvent[] TimeEvents { get; set; } = [];
    }

    public class TimeEvent
    {
        public DateTime Date { get; set; }
        public string Type { get; set; } = string.Empty; 
    }
}
