using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace PrintServerLauncher
{
    public partial class MainForm : Form, ILogger
    {
        delegate void AppendLogCallback(string log);
        private ConcurrentQueue<String> logs = new ConcurrentQueue<String>();

        public MainForm()
        {
            InitializeComponent();
            this.Hide();

            new Thread(() => { this.logAppendWorker.RunWorkerAsync(); }).Start();
        }

        public void AppendLog(String text)
        {
            logs.Enqueue(text);
        }

        private void logAppendWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            while (!this.IsDisposed)
            {
                System.Threading.Thread.Sleep(100);

                String log;
                while (logs.TryDequeue(out log))
                    AppendLogBox(log);
            }
        }

        private void AppendLogBox(string text)
        {
            if (this.logBox.InvokeRequired)
            {
                AppendLogCallback d = new AppendLogCallback(AppendLogBox);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                if (logBox.Text.Length == 0)
                    logBox.Text = text;
                else
                    logBox.AppendText("\r\n" + text);
            }
        }

        private void HideNotifyIconAndShowMainForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void ShowAboutBox()
        {
            new AboutBox().Show();
        }

        private void mainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                this.Hide();
                this.ShowInTaskbar = false;

                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(500);
            }
            else
            {
                notifyIcon.Visible = false;

                this.Show();
                this.ShowInTaskbar = true;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            HideNotifyIconAndShowMainForm();
        }

        private void title_Click(object sender, EventArgs e)
        {
            ShowAboutBox();
        }

        private void toolStripMenuItemOpenWindow_Click(object sender, EventArgs e)
        {
            HideNotifyIconAndShowMainForm();
        }

        private void toolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            ShowAboutBox();
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
