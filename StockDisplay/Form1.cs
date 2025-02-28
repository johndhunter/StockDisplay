using System.Diagnostics;
using System.Text.Json;
using T212_Updates.Domain;
using T212_Updates.Services;

namespace T212_Updates
{
    public partial class Form1 : Form
    {
        private bool isDragging = false;
        private Point offset;
        private int refreshIntervalInMilliseconds;
        private const int stockPadding = 5;
        private const int stockSpacing = 3;
        private readonly ITrading212ApiService _trading212ApiService;
        private readonly LogForm _logForm;
        private const int defaultInterval = 60000;
        private string apiKey { get; set; } = string.Empty;

        public Form1(ITrading212ApiService trading212ApiService, LogForm logForm)
        {
            InitializeComponent();

            _trading212ApiService = trading212ApiService;
            _logForm = logForm;
            AddFormEventHandlers();
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            pnlHeader.Height = lblStocksISA.Height + (2 * stockSpacing) + 6; // Padding and spacing adjustment
            pnlValue.Height = lblValue.Height + (2 * stockSpacing) + 6;
            //pnlResult.Height = lblResultValue.Height + stockSpacing + lblResultPercent.Height + (2 * stockSpacing) + 8;
            SubscribeMouseEvents(this);
        }


        #region form event handling
        private void AddFormEventHandlers()
        {
            Load += Form1_Load;
            Shown += Form1_Shown;
        }

        private void Form1_Shown(object? sender, EventArgs e)
        {
            apiKey = Properties.Settings.Default.ApiKey;
            refreshIntervalInMilliseconds = Properties.Settings.Default.RefreshFrequency * 60000;
            if (refreshIntervalInMilliseconds == 0)
            {
                refreshIntervalInMilliseconds = defaultInterval;
            }

            timeRefresh.Interval = refreshIntervalInMilliseconds;

            _ = UpdateData();

            timeRefresh.Start();
        }
        private void timeRefresh_Tick(object? sender, EventArgs e)
        {
            _ = UpdateData();
        }
        #endregion form event handling

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
            this.Close();
        }
        #endregion

        #region button handling
        private void settingsMenuItem_Click(object sender, EventArgs e)
        {
            timeRefresh.Stop();
            using (var settingsForm = new SettingsForm(_trading212ApiService, _logForm))
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    apiKey = Properties.Settings.Default.ApiKey;
                    refreshIntervalInMilliseconds = Properties.Settings.Default.RefreshFrequency * 60000;
                    _ = UpdateData();
                }
            }
            timeRefresh.Start();
        }

        private void closeMenuItem_Click(object sender, EventArgs e)
        {
            if (_logForm.Visible)
            {
                _logForm.Close();
            }
            this.Close();
        }
        #endregion

        private async Task UpdateData()
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                return;
            }

            _logForm.LogInfo("Refreshing data...");

            try
            {
                lblLastRefreshed.Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00");

                var accountCashResult = await _trading212ApiService.GetAccountCashAsync();

                if (accountCashResult.IsFailure)
                {
                    _logForm.LogError($"{Resources.Error_ApiCallFailed} : {accountCashResult.Error}");
                    UpdateDisplay(null);
                    return;
                }
                UpdateDisplay(accountCashResult.Data);

                var accountMetadataResult = await _trading212ApiService.GetAccountMetadataAsync();
                var piesResult = await _trading212ApiService.GetPiesAsync();

                if (piesResult.IsSuccess)
                {
                    foreach (var pie in piesResult.Data!)
                    {
                        await _trading212ApiService.GetPieAsync(pie.Id);
                    }
                }

                //var exchanges = await _trading212ApiService.GetExchangesAsync();
                //Trace.WriteLine($"Number of Exchanges: {exchanges.Count}");
                //foreach (var exchange in exchanges)
                //{
                //    Trace.WriteLine($"Exchange: {JsonSerializer.Serialize(exchange)}");
                //}

                //var instruments = await _trading212ApiService.GetInstrumentsAsync();
                //Trace.WriteLine($"Number of Instruments: {instruments.Count}");
                //foreach (var instrument in instruments)
                //{
                //    Trace.WriteLine($"Instrument: {JsonSerializer.Serialize(instrument)}");
                //}

                //var ordersResult = await _trading212ApiService.GetOrdersAsync();
                //Trace.WriteLine($"Number of Orders: {ordersResult.Data!.Count}");
                //foreach (var order in ordersResult.Data)
                //{
                //    Trace.WriteLine($"Order: {JsonSerializer.Serialize(order)}");
                //    await _trading212ApiService.GetOrderAsync(order.Id.ToString());
                //}

                //var positionsResult = await _trading212ApiService.GetPositionsAsync();
                //Trace.WriteLine($"Number of Positions: {positionsResult.Data!.Count}");
                //foreach (var position in positionsResult.Data)
                //{
                //    //if (instruments.Any(x => x.Ticker == position.Ticker))
                //    //{
                //    await _trading212ApiService.GetPositionAsync(position.Ticker);
                //    //await _trading212ApiService.GetPositionByTickerAsync(position.Ticker);
                //    //}
                //}

            }
            catch (Exception ex)
            {
                _logForm.LogError($"{Resources.Error_ApiCallFailed} : {ex.Message}");
                UpdateDisplay(null);
            }
        }

        private void UpdateDisplay(AccountCash? accountCash)
        {
            try
            {
                this.Invoke(() =>
                {
                    if (accountCash != null)
                    {
                        // Map the data to the labels
                        lblValue.Text = $"£{accountCash.Total}";
                        lblResultPercent.Text = $"£{accountCash.Ppl}";
                    }
                    else
                    {
                        lblValue.Text = "problem: view log";
                        lblResultPercent.Text = string.Empty;
                    }
                });
            }
            catch (Exception ex)
            {
                _logForm.LogError($"{Resources.Error_UpdateDisplayFailed} : {ex.Message}");
            }
        }
        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_logForm.Visible)
            {
                _logForm.Hide();
            }
            else
            {
                _logForm.Show();
            }
        }

        private void refreshNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = UpdateData();
        }

        private void lblLastRefreshed_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuRefresh.Show(lblLastRefreshed, e.Location);
            }
        }
    }
}