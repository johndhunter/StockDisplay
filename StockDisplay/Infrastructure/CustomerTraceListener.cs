using System;
using System.Diagnostics;

public class CustomTextWriterTraceListener : TextWriterTraceListener
{
    public CustomTextWriterTraceListener(string fileName) : base(fileName) { }

    public override void WriteLine(string? message)
    {
        if(string.IsNullOrEmpty(message))
        {
            base.WriteLine(string.Empty);
            return;
        }
        base.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
    }
}
