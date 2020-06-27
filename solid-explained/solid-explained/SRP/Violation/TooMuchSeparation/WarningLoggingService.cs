namespace solid_explained.SRP.Violation.TooMuchSeparation
{
    public class WarningLoggingService : IWarningLoggingService
    {
        private readonly IFileLogger _fileLogger;
        private readonly bool _logToFile;

        private readonly IDatabaseLogger _databaseLogger;
        private readonly bool _logToDb;

        public WarningLoggingService(
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
                string message)
        {
            if (_logToFile)
                _fileLogger.AppendToFileLog(message);

            if (_logToDb)
                _databaseLogger.AppendToDbLog(message);
        }
    }
}