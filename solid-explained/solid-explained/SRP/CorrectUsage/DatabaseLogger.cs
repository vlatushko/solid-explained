using System;

namespace solid_explained.SRP.CorrectUsage
{
    public class DatabaseLogger : IDatabaseLogger
    {
        public void Log(
                LogType logType,
                string message,
                Exception exception = null)
        {
            //logic of saving logs to a database
        }
    }
}