using System;
using System.IO;
using System.Reflection;
using System.Threading;
using log4net;
using log4net.Config;

namespace log4netLogsToElasticsearch
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(nameof(Program));

        static void Main(string[] args)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            Random random = new Random();

            // Endless loop to write logs over and over again.
            while (true)
            {
                int logLevelRandom = random.Next(0, 100);
                switch (logLevelRandom)
                {
                    case < 50:
                        log.Debug("Debug message");
                        break;
                    case < 70:
                        log.Info("Info message");
                        break;
                    case < 85:
                        log.Warn("Warning!");
                        break;
                    case < 95:
                        log.Error("Error NullReferenceException",
                            new NullReferenceException("Everything is null"));
                        break;
                    default:
                        log.Fatal("Fatal error message", new Exception("Fatal exception"));
                        break;
                }

                Thread.Sleep(TimeSpan.FromMilliseconds(random.Next(200, 5000)));
            }
        }
    }
}