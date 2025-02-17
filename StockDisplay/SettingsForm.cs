using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockDisplay
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // Load existing settings (if any) from your application's settings
            txtApiKey.Text = Properties.Settings.Default.ApiKey;
            txtRefreshFrequency.Text = Properties.Settings.Default.RefreshFrequency.ToString();

            // Populate the PIE ComboBox (this will be done asynchronously later)
            LoadPIEs();

        }
        private async Task LoadPIEs()
        {
            // Call the Trading 212 API to get the list of PIEs
            // ... (API call logic - see next step)

            // For now, let's add some dummy data
            cmbSelectPie.Items.Add("PIE1");
            cmbSelectPie.Items.Add("PIE2");

            // Select the previously selected PIE (if any)
            cmbSelectPie.SelectedItem = Properties.Settings.Default.SelectedPIE;

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

            if (!int.TryParse(txtRefreshFrequency.Text, out int refreshFrequency) || refreshFrequency <= 0)
            {
                MessageBox.Show("Invalid refresh frequency.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Save settings to your application's settings
            Properties.Settings.Default.ApiKey = txtApiKey.Text;
            Properties.Settings.Default.RefreshFrequency = refreshFrequency;
            Properties.Settings.Default.SelectedPIE = cmbSelectPie.SelectedItem?.ToString();
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
