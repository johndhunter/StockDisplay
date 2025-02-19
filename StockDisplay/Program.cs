using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http; 
using StockDisplay.Services;

namespace StockDisplay
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Console.WriteLine("Trace Listeners:"); TextWriterTraceListener listener = new TextWriterTraceListener("D:\\results.txt");
            Trace.Listeners.Add(listener);
            //foreach (TraceListener listener in Trace.Listeners)
            //{
            //    Debug.WriteLine(listener.GetType().Name);
            //}

            // Write a trace message
            Trace.WriteLine("Application starting up");
            Trace.Flush();

            var services = new ServiceCollection();

            services.AddHttpClient<ITrading212ApiService, Trading212ApiService>(client =>
            {
                // No need to set the base URL here; it's dynamic
            });

            services.AddTransient<Form1>(); // Register Form1

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var form1 = serviceProvider.GetRequiredService<Form1>(); // Resolve Form1
                Application.Run(form1);
            }
        }
    }
}