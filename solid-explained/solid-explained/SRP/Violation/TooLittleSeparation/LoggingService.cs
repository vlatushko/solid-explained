using System;

namespace solid_explained.SRP.Violation.TooLittleSeparation
{
    //This is a public interface other parts of the program will communicate by
    public interface ILoggingService
    {
        void LogInfo(
                string msg);

        void LogWarning(
                string msg);

        void LogError(
                string msg,
                Exception ex);
    }

    public enum LogType
    {
        Info,
        Warning,
        Error
    }

    //At first glimpse, the class looks correct, but actually it has two responsibilities:
    // - Log to file
    // - Log to database
    public class LoggingService : ILoggingService
    {
        //as it violates the SRP principle, we need to add some additional state to classes for
        // logic branching depending on setting of the file, which add additional complexity to the class
        private bool _logToFile;
        private bool _logToDatabase;

        public LoggingService(
                bool logToFile,
                bool logToDatabase)
        {
            _logToFile = logToFile;
            _logToDatabase = logToDatabase;
        }

        public void LogInfo(
                string msg)
        {
            Log(msg, LogType.Info);
        }

        public void LogWarning(
                string msg)
        {
            Log(msg, LogType.Warning);
        }

        public void LogError(
                string msg,
                Exception ex)
        {
            Log(msg, LogType.Error, ex);
        }

        private void Log(
                string msg,
                LogType type,
                Exception ex = null)
        {
            if (_logToFile)
                LogToFile(msg, LogType.Info);

            if (_logToDatabase)
                LogToDatabase(msg, LogType.Info);
        }

        //First responsibility
        private void LogToFile(string message, LogType type, Exception ex = null)
        {
            //Log to file logic goes here
        }

        //Second responsibility
        private void LogToDatabase(string message, LogType type, Exception ex = null)
        {
            //Log to database logic goes here
        }
    }
}