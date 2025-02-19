namespace StockDisplay
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
            lblLastRefreshed = new Label();
            lblResultPercent = new Label();
            lblResultValue = new Label();
            pnlHeader = new Panel();
            lblStocksISA = new Label();
            pnlValue = new Panel();
            lblValue = new Label();
            contextMenu = new ContextMenuStrip(components);
            settingsMenuItem = new ToolStripMenuItem();
            closeMenuItem = new ToolStripMenuItem();
            plnMain.SuspendLayout();
            pnlResult.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlValue.SuspendLayout();
            contextMenu.SuspendLayout();
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
            pnlResult.Controls.Add(lblLastRefreshed);
            pnlResult.Controls.Add(lblResultPercent);
            pnlResult.Controls.Add(lblResultValue);
            pnlResult.Location = new Point(5, 68);
            pnlResult.Name = "pnlResult";
            pnlResult.Size = new Size(141, 62);
            pnlResult.TabIndex = 3;
            // 
            // lblLastRefreshed
            // 
            lblLastRefreshed.AutoSize = true;
            lblLastRefreshed.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLastRefreshed.ForeColor = Color.White;
            lblLastRefreshed.Location = new Point(72, 38);
            lblLastRefreshed.Name = "lblLastRefreshed";
            lblLastRefreshed.Size = new Size(50, 16);
            lblLastRefreshed.TabIndex = 2;
            lblLastRefreshed.Text = "3m ago";
            // 
            // lblResultPercent
            // 
            lblResultPercent.AutoSize = true;
            lblResultPercent.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblResultPercent.ForeColor = Color.White;
            lblResultPercent.Location = new Point(5, 37);
            lblResultPercent.Name = "lblResultPercent";
            lblResultPercent.Size = new Size(62, 18);
            lblResultPercent.TabIndex = 1;
            lblResultPercent.Text = "settings";
            // 
            // lblResultValue
            // 
            lblResultValue.AutoSize = true;
            lblResultValue.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblResultValue.ForeColor = Color.White;
            lblResultValue.Location = new Point(5, 10);
            lblResultValue.Name = "lblResultValue";
            lblResultValue.Size = new Size(129, 18);
            lblResultValue.TabIndex = 0;
            lblResultValue.Text = "right click to open";
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
            lblStocksISA.Location = new Point(5, 3);
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
            lblValue.Location = new Point(5, 5);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(113, 24);
            lblValue.TabIndex = 0;
            lblValue.Text = "No Api Key";
            // 
            // contextMenu
            // 
            contextMenu.Items.AddRange(new ToolStripItem[] { settingsMenuItem, closeMenuItem });
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(117, 48);
            // 
            // settingsMenuItem
            // 
            settingsMenuItem.Name = "settingsMenuItem";
            settingsMenuItem.Size = new Size(116, 22);
            settingsMenuItem.Text = "Settings";
            settingsMenuItem.Click += settingsMenuItem_Click;
            // 
            // closeMenuItem
            // 
            closeMenuItem.Name = "closeMenuItem";
            closeMenuItem.Size = new Size(116, 22);
            closeMenuItem.Text = "Close";
            closeMenuItem.Click += closeMenuItem_Click;
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
    }
}
