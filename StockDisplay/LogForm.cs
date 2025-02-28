using T212_Updates.Infrastructure;

namespace T212_Updates
{
    public partial class LogForm : Form
    {
        private const int MAX_LINES = 1000;
        private static RichTextBox rtbLocal { get; set; } = new();

        public LogForm()
        {
            InitializeComponent();
            rtbLog.Rtf = rtbLocal.Rtf;
        }

        public void LogInfo(string message)
        {
            AppendMessage(message, Color.Green);
        }

        public void LogWarning(string message)
        {
            AppendMessage(message, Color.Orange);
        }

        public void LogError(string error)
        {
            AppendMessage(error, Color.Red);
        }

        private void AppendMessage(string message, Color color)
        {
            RollLog();

            rtbLocal.AppendText("[" + DateTime.Now.ToShortTimeString() + "]", Color.Black);
            rtbLocal.AppendText(" ");
            rtbLocal.AppendText(message + Environment.NewLine, color);
            rtbLog.Rtf = rtbLocal.Rtf;
            rtbLog.Refresh();
        }

        private void RollLog()
        {
            if (rtbLocal.Lines.Length > MAX_LINES)
            {
                rtbLocal.Select(0, rtbLog.Text.IndexOf(Environment.NewLine) + 1);
                rtbLocal.SelectedRtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1053\\uc1 }";
            }
        }

        private void LogForm_Shown(object sender, EventArgs e)
        {
            rtbLog.Rtf = rtbLocal.Rtf;
            rtbLog.Refresh();
        }

        private void LogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Visible = false;
                return;
            }
        }

        private void LogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                this.Visible = false;
                return;
            }
        }
    }
}
