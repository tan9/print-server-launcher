using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

                process = new Process();
                process.StartInfo = start;

                ThreadStart threadStart = new ThreadStart(() =>
                {
                    bool exitCode = process.Start();
                });
                Thread thread = new Thread(threadStart);
                thread.Start();
            }
        }

        public void Stop()
        {
            if (process != null)
            {
                process.Kill();
                process = null;
            }
        }
    }
}
