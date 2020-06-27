using System;

namespace solid_explained.SRP.CorrectUsage
{
    public class FileLogger : IFileLogger
    {
        public void Log(
                LogType logType,
                string message,
                Exception exception = null)
        {
            //log to file logic
        }
    }
}