using System;
using System.ComponentModel;
using System.IO;
using System.Threading;

namespace PrintServerLauncher
{
    class LogTailer
    {
        private Boolean stopped = false;

        public void TailLog(String fileName, ILogger logger)
        {
            ThreadStart threadStart = new ThreadStart(() =>
            {
                // code snippet taken from http://www.codeproject.com/Articles/7568/Tail-NET
                using (StreamReader reader = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    // start at the end of the file
                    long lastMaxOffset = reader.BaseStream.Length;

                    while (!stopped)
                    {
                        System.Threading.Thread.Sleep(100);

                        // if the file size has not changed, idle
                        if (reader.BaseStream.Length == lastMaxOffset)
                            continue;

                        // seek to the last max offset
                        reader.BaseStream.Seek(lastMaxOffset, SeekOrigin.Begin);

                        // read out of the file until the EOF
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                            logger.AppendLog(line);

                        // update the last max offset
                        lastMaxOffset = reader.BaseStream.Position;
                    }
                }
            });
            Thread thread = new Thread(threadStart);
            thread.Start();
        }

        public void Stop()
        {
            stopped = true;
        }
    }
}
