using NLog;
using NLog.Config;
using NLog.Targets;
using Prism.Logging;

namespace WpfEQDValidationApp.DataServices
{
    public class LogService : ILoggerFacade
    {
        public static Logger Instance { get; private set; }

        public LogService()
        {
            //LogManager.Configuration = new XmlLoggingConfiguration(@"\\variancom\va_data$\filedata\ProgramData\Vision\PublishedScripts\NLog.config");
            //#if DEBUG
            var config = new LoggingConfiguration();


            // Setup the logging view for Sentinel - http://sentinel.codeplex.com
            var sentinalTarget = new NLogViewerTarget()
            {
                Name = "sentinal",
                Address = "udp://10.221.45.179:9999",
                IncludeNLogData = false
            };
            var sentinalRule = new LoggingRule("*", LogLevel.Trace, sentinalTarget);

            config.AddTarget("sentinal", sentinalTarget);
            config.LoggingRules.Add(sentinalRule);

            //LogManager.Configuration.AddTarget("sentinal", sentinalTarget);
            //LogManager.Configuration.LoggingRules.Add(sentinalRule);

            //// Setup the logging view for Harvester - http://harvester.codeplex.com
            //var harvesterTarget = new OutputDebugStringTarget()
            //{
            //    Name = "harvester",
            //    Layout = "${log4jxmlevent:includeNLogData=false}"
            //};
            //var harvesterRule = new LoggingRule("*", LogLevel.Trace, harvesterTarget);
            //LogManager.Configuration.AddTarget("harvester", harvesterTarget);
            //LogManager.Configuration.LoggingRules.Add(harvesterRule);
            //#endif

            //LogManager.ReconfigExistingLoggers();

            LogManager.Configuration = config;
            Instance = LogManager.GetCurrentClassLogger();

        }

        public void Log(string message, Category category, Priority priority)
        {
            switch (category)
            {
                case Category.Debug:
                    Instance.Debug(message);
                    break;
                case Category.Warn:
                    Instance.Trace(message);
                    break;
                default:
                    Instance.Info(message);
                    break;

            }
        }
    }
}