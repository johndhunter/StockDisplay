using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
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

            CustomTextWriterTraceListener listener = new CustomTextWriterTraceListener("C:\\results.txt");
            Trace.Listeners.Add(listener);

            Trace.WriteLine("Application starting up");
            Trace.Flush();

            var services = new ServiceCollection();

            services.AddHttpClient<ITrading212ApiService, Trading212ApiService>(client =>
            {
            });

            services.AddTransient<Form1>(); 

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var form1 = serviceProvider.GetRequiredService<Form1>(); // Resolve Form1
                Application.Run(form1);
            }
        }
    }
}