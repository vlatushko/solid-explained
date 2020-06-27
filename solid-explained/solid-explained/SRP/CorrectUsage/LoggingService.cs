using System;

namespace solid_explained.SRP.CorrectUsage
{
    //The classes that will use this logger will need to inject only one interface "ILoggerService"
    public class LoggingService : ILoggingService
    {
        //as you can see it requires only the base logger interface without
        // worrying where the log should be saved
        private readonly ILogger _logger;

        //NOTE: it DOESN'T require any state for conditional logging!

        public LoggingService(
                ILogger logger)
        {
            _logger = logger;
        }

        public void LogInfo(
                string message)
        {
            _logger.Log(LogType.Info, message);
        }

        public void LogWarning(
                string message)
        {
            _logger.Log(LogType.Warning, message);
        }

        public void LogError(
                string message,
                Exception exception)
        {
            _logger.Log(LogType.Error, message, exception);
        }
    }
}