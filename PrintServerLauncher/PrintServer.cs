using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace PrintServerLauncher
{
    class PrintServer
    {
        private const String PROCESS_EXECUTABLE_NAME = "print-server.exe";
        private const String PROCESS_LOG_FILE_NAME = "print-server.log";

        private Process process;
        private String processLocation;

        public PrintServer()
        {
            String[] locations = { System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0, System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf("\\")) , "D:\\development\\repositories\\print-server" };
            foreach (String location in locations)
                if (File.Exists(location + "\\" + PROCESS_EXECUTABLE_NAME))
                {
                    processLocation = location;
                    break;
                }

            if (processLocation == null)
                throw new InvalidOperationException("Cannot locate \"print-server.exe\" executable.");
        }

        public void Run()
        {
            if (process == null)
            {
                Process[] processesExisted = Process.GetProcessesByName("print-server");

                if (processesExisted.Length == 0)
                {
                    ProcessStartInfo start = new ProcessStartInfo();
                    start.FileName = processLocation +  "\\" + PROCESS_EXECUTABLE_NAME;
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

        public String GetLogFileName()
        {
            return processLocation + "\\" + PROCESS_LOG_FILE_NAME;
        }
    }
}
