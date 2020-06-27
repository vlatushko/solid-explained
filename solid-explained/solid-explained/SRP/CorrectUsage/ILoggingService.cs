using System;

namespace solid_explained.SRP.CorrectUsage
{
    public interface ILoggingService
    {
        void LogInfo(
                string message);

        void LogWarning(
                string message);

        void LogError(
                string message,
                Exception exception);
    }
}