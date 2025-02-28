namespace T212_Updates
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            plnMain = new Panel();
            pnlResult = new Panel();
            label1 = new Label();
            lblLastRefreshed = new Label();
            lblResultPercent = new Label();
            pnlHeader = new Panel();
            lblStocksISA = new Label();
            pnlValue = new Panel();
            lblValue = new Label();
            contextMenu = new ContextMenuStrip(components);
            settingsMenuItem = new ToolStripMenuItem();
            logToolStripMenuItem = new ToolStripMenuItem();
            closeMenuItem = new ToolStripMenuItem();
            timeRefresh = new System.Windows.Forms.Timer(components);
            toolTip1 = new ToolTip(components);
            contextMenuRefresh = new ContextMenuStrip(components);
            refreshNowToolStripMenuItem = new ToolStripMenuItem();
            plnMain.SuspendLayout();
            pnlResult.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlValue.SuspendLayout();
            contextMenu.SuspendLayout();
            contextMenuRefresh.SuspendLayout();
            SuspendLayout();
            // 
            // plnMain
            // 
            plnMain.BackColor = Color.Black;
            plnMain.Controls.Add(pnlResult);
            plnMain.Controls.Add(pnlHeader);
            plnMain.Controls.Add(pnlValue);
            plnMain.Dock = DockStyle.Fill;
            plnMain.Location = new Point(0, 0);
            plnMain.Name = "plnMain";
            plnMain.Padding = new Padding(5);
            plnMain.Size = new Size(153, 134);
            plnMain.TabIndex = 0;
            // 
            // pnlResult
            // 
            pnlResult.Controls.Add(label1);
            pnlResult.Controls.Add(lblLastRefreshed);
            pnlResult.Controls.Add(lblResultPercent);
            pnlResult.Location = new Point(5, 68);
            pnlResult.Name = "pnlResult";
            pnlResult.Size = new Size(141, 62);
            pnlResult.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(-4, 35);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 3;
            label1.Text = "Last Update";
            // 
            // lblLastRefreshed
            // 
            lblLastRefreshed.AutoSize = true;
            lblLastRefreshed.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLastRefreshed.ForeColor = Color.White;
            lblLastRefreshed.Location = new Point(79, 35);
            lblLastRefreshed.Name = "lblLastRefreshed";
            lblLastRefreshed.Size = new Size(50, 16);
            lblLastRefreshed.TabIndex = 2;
            lblLastRefreshed.Text = "0m ago";
            lblLastRefreshed.MouseUp += lblLastRefreshed_MouseUp;
            // 
            // lblResultPercent
            // 
            lblResultPercent.AutoSize = true;
            lblResultPercent.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblResultPercent.ForeColor = Color.White;
            lblResultPercent.Location = new Point(-5, 0);
            lblResultPercent.Name = "lblResultPercent";
            lblResultPercent.Size = new Size(94, 18);
            lblResultPercent.TabIndex = 1;
            lblResultPercent.Text = "Use settings";
            toolTip1.SetToolTip(lblResultPercent, "This is the ppl value");
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblStocksISA);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(5, 5);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(0, 3, 0, 3);
            pnlHeader.Size = new Size(143, 26);
            pnlHeader.TabIndex = 2;
            // 
            // lblStocksISA
            // 
            lblStocksISA.AutoSize = true;
            lblStocksISA.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStocksISA.ForeColor = Color.DeepSkyBlue;
            lblStocksISA.Location = new Point(-5, 3);
            lblStocksISA.Margin = new Padding(0);
            lblStocksISA.Name = "lblStocksISA";
            lblStocksISA.Size = new Size(85, 18);
            lblStocksISA.TabIndex = 1;
            lblStocksISA.Text = "Stocks ISA";
            // 
            // pnlValue
            // 
            pnlValue.Controls.Add(lblValue);
            pnlValue.Location = new Point(5, 33);
            pnlValue.Name = "pnlValue";
            pnlValue.Padding = new Padding(0, 3, 0, 3);
            pnlValue.Size = new Size(141, 33);
            pnlValue.TabIndex = 1;
            // 
            // lblValue
            // 
            lblValue.AutoSize = true;
            lblValue.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblValue.ForeColor = Color.White;
            lblValue.Location = new Point(-5, 3);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(113, 24);
            lblValue.TabIndex = 0;
            lblValue.Text = "No Api Key";
            toolTip1.SetToolTip(lblValue, "This is the cash value");
            // 
            // contextMenu
            // 
            contextMenu.Items.AddRange(new ToolStripItem[] { settingsMenuItem, logToolStripMenuItem, closeMenuItem });
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(117, 70);
            // 
            // settingsMenuItem
            // 
            settingsMenuItem.Name = "settingsMenuItem";
            settingsMenuItem.Size = new Size(116, 22);
            settingsMenuItem.Text = "Settings";
            settingsMenuItem.Click += settingsMenuItem_Click;
            // 
            // logToolStripMenuItem
            // 
            logToolStripMenuItem.Name = "logToolStripMenuItem";
            logToolStripMenuItem.Size = new Size(116, 22);
            logToolStripMenuItem.Text = "Log";
            logToolStripMenuItem.Click += logToolStripMenuItem_Click;
            // 
            // closeMenuItem
            // 
            closeMenuItem.Name = "closeMenuItem";
            closeMenuItem.Size = new Size(116, 22);
            closeMenuItem.Text = "Close";
            closeMenuItem.Click += closeMenuItem_Click;
            // 
            // timeRefresh
            // 
            timeRefresh.Interval = 10000;
            timeRefresh.Tick += timeRefresh_Tick;
            // 
            // toolTip1
            // 
            toolTip1.Popup += toolTip1_Popup;
            // 
            // contextMenuRefresh
            // 
            contextMenuRefresh.Items.AddRange(new ToolStripItem[] { refreshNowToolStripMenuItem });
            contextMenuRefresh.Name = "contextMenuRefreh";
            contextMenuRefresh.Size = new Size(181, 48);
            // 
            // refreshNowToolStripMenuItem
            // 
            refreshNowToolStripMenuItem.Name = "refreshNowToolStripMenuItem";
            refreshNowToolStripMenuItem.Size = new Size(180, 22);
            refreshNowToolStripMenuItem.Text = "Refresh Now";
            refreshNowToolStripMenuItem.Click += refreshNowToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(153, 134);
            ContextMenuStrip = contextMenu;
            Controls.Add(plnMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
            MouseUp += Form1_MouseUp;
            plnMain.ResumeLayout(false);
            pnlResult.ResumeLayout(false);
            pnlResult.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlValue.ResumeLayout(false);
            pnlValue.PerformLayout();
            contextMenu.ResumeLayout(false);
            contextMenuRefresh.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel plnMain;
        private Panel pnlValue;
        private Panel pnlHeader;
        private Label lblStocksISA;
        private Label lblValue;
        private Panel pnlResult;
        private Label lblResultValue;
        private Label lblLastRefreshed;
        private Label lblResultPercent;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem settingsMenuItem;
        private ToolStripMenuItem closeMenuItem;
        private Label label1;
        private System.Windows.Forms.Timer timeRefresh;
        private ToolTip toolTip1;
        private ToolStripMenuItem logToolStripMenuItem;
        private ContextMenuStrip contextMenuRefresh;
        private ToolStripMenuItem refreshNowToolStripMenuItem;
    }
}
