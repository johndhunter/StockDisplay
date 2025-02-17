namespace StockDisplay
{
    public partial class Form1 : Form
    {
        private bool isDragging = false;
        private Point offset;
        private const int stockPadding = 5;
        private const int stockSpacing = 3;

        public Form1()
        {
            InitializeComponent();
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;

            this.Load += Form1_Load;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            pnlHeader.Height = lblStocksISA.Height + (2 * stockSpacing) + 6; // Padding and spacing adjustment
            pnlValue.Height = lblValue.Height + (2 * stockSpacing) + 6;
            pnlResult.Height = lblResultValue.Height + stockSpacing + lblResultPercent.Height + (2 * stockSpacing) + 8;

            SubscribeMouseEvents(this);
        }
        // Recursive function to subscribe to mouse events for all controls

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

        private void settingsMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(); // Assuming you have a SettingsForm
            settingsForm.ShowDialog(); // Show it as a modal dialog
        }

        private void closeMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form
        }
    }
}