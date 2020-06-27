using System;

namespace solid_explained.SRP.Violation.TooMuchSeparation
{
    public class ErrorLoggingService : IErrorLoggingService
    {
        private readonly IFileLogger _fileLogger;
        private readonly IDatabaseLogger _databaseLogger;

        //requires additional state which makes the usage of the service inconvenient
        private readonly bool _logToFile;
        private readonly bool _logToDb;


        public ErrorLoggingService(
                IFileLogger fileLogger,
                bool logToFile,
                IDatabaseLogger databaseLogger,
                bool logToDb)
        {
            _fileLogger = fileLogger;
            _logToFile = logToFile;

            _databaseLogger = databaseLogger;
            _logToDb = logToDb;
        }

        public void Log(
                string message,
                Exception exception)
        {
            var finalLog = FormatLog(message, exception);

            //this part of code is the same with WarningLogging and InfoLogging services
            //can be refactored out to the base Logging class but it's not our purpose now
            if (_logToFile)
                _fileLogger.AppendToFileLog(finalLog);

            if (_logToDb)
                _databaseLogger.AppendToDbLog(finalLog);
        }

        private string FormatLog(string logMessage, Exception exception)
        {
            //just an example formatting
            return $"LogMessage: {logMessage}, Exception: {exception.Message}";
        }
    }
}