using System;

namespace solid_explained.SRP.CorrectUsage
{
    public interface ILogger
    {
        void Log(
                LogType logType,
                string message,
                Exception exception = null);
    }
}