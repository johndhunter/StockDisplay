namespace StockDisplay
{
    public partial class Form1 : Form
    {
        private bool isDragging = false;
        private Point offset;

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
            foreach (Control control in this.Controls)
            {
                control.MouseDown += Form1_MouseDown;
                control.MouseMove += Form1_MouseMove;
                control.MouseUp += Form1_MouseUp;
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
    }
}