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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm mainForm = new MainForm();

            PrintServer server = new PrintServer();
            AppDomain.CurrentDomain.ProcessExit += (sender, eventArgs) => server.Stop();
            server.Run();

            LogTailer logTailer = new LogTailer();
            logTailer.TailLog("D:/development/repositories/print-server/print-server.log", mainForm);
            mainForm.Disposed += (sender, eventArgs) => logTailer.Stop();

            Application.Run(mainForm);
        }
    }
}
