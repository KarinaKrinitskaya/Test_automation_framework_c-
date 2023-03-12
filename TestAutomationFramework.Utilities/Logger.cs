using NLog;

namespace TestAutomationFramework.Utilities
{
    public static class Logger
    {
        private static NLog.Logger logger = null;

        public static void Info(string message)
        {
            logger.Info(message);
        }

        public static void Error(string message)
        {
            logger.Error(message);
        }

        public static void Initialize(string logFilePath = ".//Logs//log.txt")
        {
            if (logger != null)
                return;

            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = logFilePath, CreateDirs = true };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            LogManager.Configuration = config;

            logger = LogManager.GetCurrentClassLogger();
        }
    }
}