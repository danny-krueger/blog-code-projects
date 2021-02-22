using System.IO;
using System.Reflection;
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


            log.Info("Test Test");
        }
    }
}
