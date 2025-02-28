namespace T212_Updates
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblApiKey = new Label();
            txtApiKey = new TextBox();
            lblRefreshFrequency = new Label();
            lblSelectPie = new Label();
            cmbSelectPie = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            numRefreshFrequency = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numRefreshFrequency).BeginInit();
            SuspendLayout();
            // 
            // lblApiKey
            // 
            lblApiKey.AutoSize = true;
            lblApiKey.Location = new Point(11, 6);
            lblApiKey.Name = "lblApiKey";
            lblApiKey.Size = new Size(47, 15);
            lblApiKey.TabIndex = 0;
            lblApiKey.Text = "Api Key";
            // 
            // txtApiKey
            // 
            txtApiKey.Location = new Point(11, 24);
            txtApiKey.Name = "txtApiKey";
            txtApiKey.Size = new Size(249, 23);
            txtApiKey.TabIndex = 1;
            // 
            // lblRefreshFrequency
            // 
            lblRefreshFrequency.AutoSize = true;
            lblRefreshFrequency.Location = new Point(11, 57);
            lblRefreshFrequency.Name = "lblRefreshFrequency";
            lblRefreshFrequency.Size = new Size(158, 15);
            lblRefreshFrequency.TabIndex = 2;
            lblRefreshFrequency.Text = "Refresh Frequency (minutes)";
            // 
            // lblSelectPie
            // 
            lblSelectPie.AutoSize = true;
            lblSelectPie.Location = new Point(11, 109);
            lblSelectPie.Name = "lblSelectPie";
            lblSelectPie.Size = new Size(57, 15);
            lblSelectPie.TabIndex = 4;
            lblSelectPie.Text = "Select PIE";
            lblSelectPie.Visible = false;
            // 
            // cmbSelectPie
            // 
            cmbSelectPie.FormattingEnabled = true;
            cmbSelectPie.Location = new Point(11, 127);
            cmbSelectPie.Name = "cmbSelectPie";
            cmbSelectPie.Size = new Size(239, 23);
            cmbSelectPie.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(94, 156);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(175, 156);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // numRefreshFrequency
            // 
            numRefreshFrequency.Location = new Point(11, 78);
            numRefreshFrequency.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            numRefreshFrequency.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numRefreshFrequency.Name = "numRefreshFrequency";
            numRefreshFrequency.Size = new Size(47, 23);
            numRefreshFrequency.TabIndex = 8;
            numRefreshFrequency.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(281, 182);
            ControlBox = false;
            Controls.Add(numRefreshFrequency);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cmbSelectPie);
            Controls.Add(lblSelectPie);
            Controls.Add(lblRefreshFrequency);
            Controls.Add(txtApiKey);
            Controls.Add(lblApiKey);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            HelpButton = true;
            Name = "SettingsForm";
            Text = "Settings";
            Load += SettingsForm_Load;
            ((System.ComponentModel.ISupportInitialize)numRefreshFrequency).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblApiKey;
        private TextBox txtApiKey;
        private Label lblRefreshFrequency;
        private Label lblSelectPie;
        private ComboBox cmbSelectPie;
        private Button btnSave;
        private Button btnCancel;
        private NumericUpDown numRefreshFrequency;
    }
}