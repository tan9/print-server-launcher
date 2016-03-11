using System;
using System.Diagnostics;
using System.Threading;

namespace PrintServerLauncher
{
    class PrintServer
    {
        Process process;

        public void Run()
        {
            if (process == null)
            {
                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = "D:/development/repositories/print-server/print-server.exe";
                start.WindowStyle = ProcessWindowStyle.Hidden;
                start.CreateNoWindow = true;

                Process[] processesExisted = Process.GetProcessesByName("print-server");

                if (processesExisted.Length == 0)
                {
                    process = new Process();
                    process.StartInfo = start;

                    ThreadStart threadStart = new ThreadStart(() =>
                    {
                        bool exitCode = process.Start();
                    });
                    Thread thread = new Thread(threadStart);
                    thread.Start();
                }
                else if (processesExisted.Length == 1)
                {
                    process = processesExisted[0];
                }
                else
                {
                    throw new InvalidOperationException("Found more than one existing printer-server processes.");
                }
            }
        }

        public void Stop()
        {
            if (process != null && !process.HasExited)
            {
                process.Kill();
                process = null;
            }
        }
    }
}
