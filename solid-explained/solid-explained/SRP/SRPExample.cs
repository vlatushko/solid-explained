using System;

namespace solid_explained.SRP
{
    public class SRPExample
    {
        public SRPExample()
        {

            //en example of configuration of the approach from Too Little Separation
            const bool logToFile = false;
            const bool logToDatabase = true;

            var _loggingService = new Violation.TooLittleSeparation.LoggingService(logToFile, logToDatabase);

            _loggingService.LogInfo("Info log");
            _loggingService.LogWarning("Warning log");
            _loggingService.LogError("Error log", new Exception("Some exception"));
            //***

            //en example of configuration of the approach from Too Much Concerns
            var fileLogger = new Violation.TooMuchSeparation.FileLogger();
            var databaseLogger = new Violation.TooMuchSeparation.DatabaseLogger();

            //as you can see, if we have too much SOC we will get tired configuring it and
            //there will be a lot of duplication
            //Just imagine how the configuration would grow if we had to add 5 more logger types :)
            var infoLoggingService =
                    new Violation.TooMuchSeparation.InfoLoggingService(fileLogger,
                            logToFile,
                            databaseLogger,
                            logToDatabase);

            var warningLoggingService =
                    new Violation.TooMuchSeparation.WarningLoggingService(fileLogger,
                            logToFile,
                            databaseLogger,
                            logToDatabase);

            var errorLoggingService =
                    new Violation.TooMuchSeparation.ErrorLoggingService(fileLogger,
                            logToFile,
                            databaseLogger,
                            logToDatabase);

            //usage
            infoLoggingService.Log("Info log");
            warningLoggingService.Log("Warning log");
            errorLoggingService.Log("Error log", new Exception("Some exception message"));
            //***

            //Correct Usage example configuration
            //let's get an appropriate logger base on dummy configuration
            var logger = LoggerFactory(LoggerType.DatabaseLogger);
            var ls = new CorrectUsage.LoggingService(logger);

            ls.LogInfo("Info log");
            ls.LogWarning("Log warning");
            ls.LogError("Log error", new Exception("Some exception message"));
            //***
        }

        enum LoggerType
        {
            FileLogger,
            DatabaseLogger
        }

        private CorrectUsage.ILogger LoggerFactory(
                LoggerType loggerType)
        {
            return loggerType switch
            {
                LoggerType.FileLogger => new CorrectUsage.FileLogger(),
                LoggerType.DatabaseLogger => new CorrectUsage.DatabaseLogger(),
                _ => null
            };
        }
    }
}