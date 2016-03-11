using System;
using System.Windows.Forms;

namespace PrintServerLauncher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                MainForm mainForm = new MainForm();

                PrintServer server = new PrintServer();
                AppDomain.CurrentDomain.ProcessExit += (sender, eventArgs) => server.Stop();

                LogTailer logTailer = new LogTailer();
                logTailer.TailLog(server.GetLogFileName(), mainForm);
                mainForm.Disposed += (sender, eventArgs) => logTailer.Stop();

                server.Run();
                Application.Run(mainForm);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
