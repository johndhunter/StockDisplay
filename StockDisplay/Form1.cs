using System.Diagnostics;
using System.Resources;
using System.Text.Json;
using StockDisplay.Domain;
using StockDisplay.Services;

namespace StockDisplay
{
    public partial class Form1 : Form
    {
        private bool isDragging = false;
        private Point offset;
        private const int stockPadding = 5;
        private const int stockSpacing = 3;
        private readonly ITrading212ApiService _trading212ApiService; // Inject the typed client
        private string apiKey { get; set; } = string.Empty;

        public Form1(ITrading212ApiService trading212ApiService)
        {
            InitializeComponent();

            _trading212ApiService = trading212ApiService;

            AddFormEventHandlers();
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            pnlHeader.Height = lblStocksISA.Height + (2 * stockSpacing) + 6; // Padding and spacing adjustment
            pnlValue.Height = lblValue.Height + (2 * stockSpacing) + 6;
            pnlResult.Height = lblResultValue.Height + stockSpacing + lblResultPercent.Height + (2 * stockSpacing) + 8;

            SubscribeMouseEvents(this);


        }
        #region add handlers
        private void AddFormEventHandlers()
        {
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
            MouseUp += Form1_MouseUp;

            Load += Form1_Load;
            Shown += Form1_Shown;
        }

        private void Form1_Shown(object? sender, EventArgs e)
        {
            apiKey = Properties.Settings.Default.ApiKey; // Get API key from settings
            if (!string.IsNullOrEmpty(apiKey))
            {
                _ = LoadData(); // Load data asynchronously
            }
        }
        #endregion
        #region mouse handling
        private void SubscribeMouseEvents(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                control.MouseDown += Form1_MouseDown;
                control.MouseMove += Form1_MouseMove;
                control.MouseUp += Form1_MouseUp;
                control.MouseDoubleClick += Form1_MouseDoubleClick!;
                // Recursively subscribe for nested controls
                if (control.HasChildren)
                {
                    SubscribeMouseEvents(control);
                }
            }
        }

        private void Form1_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                offset = new Point(e.X, e.Y); // Capture offset relative to the control
            }
        }

        private void Form1_MouseMove(object? sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentScreenPos = Cursor.Position;
                this.Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void Form1_MouseUp(object? sender, MouseEventArgs e)
        {
            isDragging = false;
        }
        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close(); // Close the form on double-click
        }
        #endregion
        #region button handling
        private void settingsMenuItem_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new SettingsForm(_trading212ApiService)) // Pass the service
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    _ = LoadData(); // Refresh data
                }
            }
        }

        private void closeMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form
        }
        #endregion

        private async Task LoadData()
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                return;
            }

            try
            {
                AccountCash accountCash = await _trading212ApiService.GetAccountCashAsync();

                UpdateCashData(accountCash);

                var accountMetadata = await _trading212ApiService.GetAccountMetadataAsync();

                var pies = await _trading212ApiService.GetPiesAsync();

                Trace.WriteLine($"Number of Pies: {pies.Count}");
                foreach (var pie in pies)
                {
                    await _trading212ApiService.GetPieAsync(pie.Id);
                }

                var exchanges = await _trading212ApiService.GetExchangesAsync();
                Trace.WriteLine($"Number of Exchanges: {exchanges.Count}");
                foreach (var exchange in exchanges)
                {
                    Trace.WriteLine($"Exchange: {JsonSerializer.Serialize(exchange)}");
                }

                var instruments = await _trading212ApiService.GetInstrumentsAsync();
                Trace.WriteLine($"Number of Instruments: {instruments.Count}");
                foreach (var instrument in instruments)
                {
                    Trace.WriteLine($"Instrument: {JsonSerializer.Serialize(instrument)}");
                }

                var orders = await _trading212ApiService.GetOrdersAsync();
                Trace.WriteLine($"Number of Orders: {orders.Count}");
                foreach (var order in orders)
                {
                    Trace.WriteLine($"Order: {JsonSerializer.Serialize(order)}");
                    await _trading212ApiService.GetOrderAsync(order.Id.ToString());
                }

                var positions = await _trading212ApiService.GetPositionsAsync();
                Trace.WriteLine($"Number of Positions: {positions.Count}");
                foreach (var position in positions)
                {
                    if (instruments.Any(x => x.Ticker == position.Ticker))
                    {
                        await _trading212ApiService.GetPositionAsync(position.Ticker);
                        await _trading212ApiService.GetPositionByTickerAsync(position.Ticker);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.Error_ApiCallFailed + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateCashData(null);
            }
        }

        private void UpdateUIData(PieDetail? pieDetail)
        {
            //this.Invoke(() =>
            //{
            //    if (pieDetail != null && pieDetail.Instruments != null && pieDetail.Instruments.Length > 0)
            //    {
            //        // Assuming you want to display data for the first instrument (adjust as needed)
            //        var instrument = pieDetail.Instruments[0]; // Get the first instrument

            //        // Map the data to the labels
            //        lblValue.Text = instrument.Result.PriceAvgValue.ToString("N2"); // Format as currency (replace with your desired format)

            //        // For lblResultValue and lblResultPercent, you'll need to decide which values to display.
            //        // Based on the JSON you provided, the Instrument.Result object has the following:
            //        // PriceAvgInvestedValue
            //        // PriceAvgResult
            //        // PriceAvgResultCoef
            //        // PriceAvgValue

            //        // Example: Display PriceAvgResult in lblResultValue and PriceAvgResultCoef in lblResultPercent
            //        lblResultValue.Text = instrument.Result.PriceAvgResult.ToString("N2"); // Format as currency (replace with your desired format)
            //        lblResultPercent.Text = instrument.Result.PriceAvgResultCoef.ToString("P2"); // Format as percentage (replace with your desired format)
            //    }
            //    else
            //    {
            //        // Handle cases where pieDetails or instruments are null or empty
            //        lblValue.Text = "N/A";
            //        lblResultValue.Text = "N/A";
            //        lblResultPercent.Text = "N/A";
            //    }
            //});
        }
        private void UpdateCashData(AccountCash? accountCash)
        {
            this.Invoke(() =>
            {
                if (accountCash != null)
                {
                    // Map the data to the labels
                    lblValue.Text = $"£{accountCash.Invested}";
                    lblResultValue.Text = $"£{accountCash.Result}";
                    lblResultPercent.Text = $"£{accountCash.Ppl}";
                    lblLastRefreshed.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                }
                else
                {
                    // Handle cases where pieDetails or instruments are null or empty
                    lblValue.Text = "N/A";
                    lblResultValue.Text = "N/A";
                    lblResultPercent.Text = "N/A";
                }
            });
        }
    }
}