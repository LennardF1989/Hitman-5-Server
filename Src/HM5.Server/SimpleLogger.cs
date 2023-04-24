using HM5.Server.Interfaces;

namespace HM5.Server
{
    public class SimpleLogger : IDisposable, ISimpleLogger
    {
        private static readonly object _writerLock = new();

        private readonly StreamWriter _writer;

        public SimpleLogger(string basePath)
        {
            var directoryPath = Path.Combine(basePath, "Logs");
            var logPath = Path.Combine(directoryPath, "debug.txt");

            Directory.CreateDirectory(directoryPath);

            var logFile = new FileInfo(logPath);

            if (logFile.Exists && logFile.Length > 0)
            {
                File.Move(
                    logPath, 
                    Path.Combine(directoryPath, $"debug_{(int)(DateTime.Now - DateTime.UnixEpoch).TotalSeconds}.txt")
                );
            }

            _writer = new StreamWriter(new FileStream(logPath, FileMode.Create, FileAccess.Write))
            {
                AutoFlush = true
            };
        }

        public void WriteLine(string message)
        {
            lock (_writerLock)
            {
                _writer.WriteLine(message);
            }

            Console.WriteLine(message);
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            lock (_writerLock)
            {
                _writer?.Dispose();
            }
        }
    }
}
