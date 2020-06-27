namespace solid_explained.SRP.Violation.TooMuchSeparation
{
    public interface IFileLogger
    {
        void AppendToFileLog(
                string logMessage);
    }
}