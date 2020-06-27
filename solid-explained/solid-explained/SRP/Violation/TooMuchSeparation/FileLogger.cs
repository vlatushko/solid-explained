namespace solid_explained.SRP.Violation.TooMuchSeparation
{
    public class FileLogger : IFileLogger
    {
        public void AppendToFileLog(
                string logMessage)
        {
            //logic of writing the logMessage to a log file;
        }
    }
}