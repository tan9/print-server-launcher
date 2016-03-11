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
            PrintServer server = new PrintServer();
            AppDomain.CurrentDomain.ProcessExit += (sender, eventArgs) => server.Stop();
            server.Run();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
