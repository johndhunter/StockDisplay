﻿using T212_Updates.Services;

namespace T212_Updates
{
    public partial class SettingsForm : Form
    {
        private readonly ITrading212ApiService _trading212ApiService;
        private readonly LogForm logForm;

        private string apiKey { get; set; } = string.Empty;
        private int refreshFrequency { get; set; } = 0;

        
        public SettingsForm(ITrading212ApiService trading212ApiService, LogForm logForm)
        {
            InitializeComponent();
            _trading212ApiService = trading212ApiService;
            this.logForm = logForm;
            apiKey = Properties.Settings.Default.ApiKey;
            refreshFrequency = Properties.Settings.Default.RefreshFrequency;
            if(refreshFrequency == 0)
            {
                refreshFrequency = 10;
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            txtApiKey.Text = apiKey;
            numRefreshFrequency.Text = refreshFrequency.ToString();

            if (string.IsNullOrEmpty(apiKey))
            {
                return;
            }

            _ = GetPieDropdownItems();

        }

        private async Task GetPieDropdownItems()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtApiKey.Text))
                {
                    var pies = await _trading212ApiService.GetPiesAsync(); // Use injected service

                    await this.Invoke(async () => 
                    {
                        cmbSelectPie.Items.Clear();
                        if (pies != null && pies.Data != null && pies.Data.Count > 0)
                        {
                            await PopulatePieDropdown(pies.Data);
                        }
                        else
                        {
                            logForm.LogWarning(Resources.Error_NoPiesFound);
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading PIEs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task PopulatePieDropdown(List<Domain.Pie> pies)
        {
            foreach (var pie in pies)
            {
                Task.Delay(1000).Wait(); // Delay to avoid rate limiting

                var pieDetailResult = await _trading212ApiService.GetPieAsync(pie.Id);
                cmbSelectPie.Items.Add(new { Id = pie.Id, Name = pieDetailResult!.Data!.Settings.Name });
            }

            if (Properties.Settings.Default.SelectedPie != 0)
            {
                cmbSelectPie.SelectedItem = pies.Find(p => p.Id == Properties.Settings.Default.SelectedPie);
            }
            else if (cmbSelectPie.Items.Count > 0)
            {
                cmbSelectPie.SelectedIndex = 0;
            }

            if (cmbSelectPie.Items.Count == 1)
            {
                cmbSelectPie.Enabled = false; // Disable if only one PIE
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate input (API key, refresh frequency)
            if (string.IsNullOrEmpty(txtApiKey.Text))
            {
                MessageBox.Show("API Key cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(numRefreshFrequency.Text, out int refreshFrequency) || refreshFrequency <= 0)
            {
                MessageBox.Show("Invalid refresh frequency.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Save settings to your application's settings
            Properties.Settings.Default.ApiKey = txtApiKey.Text;
            Properties.Settings.Default.RefreshFrequency = refreshFrequency;
            //todo uncomment this
//            Properties.Settings.Default.SelectedPie = (int)cmbSelectPie.SelectedItem!;
            Properties.Settings.Default.Save();

            this.DialogResult = DialogResult.OK; // Indicate that settings were saved
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Indicate that settings were cancelled
            this.Close();
        }
    }
}
