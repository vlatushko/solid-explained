using System;

namespace solid_explained.SRP.Violation.TooMuchSeparation
{
    public interface IErrorLoggingService
    {
        void Log(
                string message,
                Exception exception);
    }
}