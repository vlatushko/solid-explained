namespace solid_explained.SRP.Violation.TooMuchSeparation
{
    public class DatabaseLogger : IDatabaseLogger
    {
        public void AppendToDbLog(
                string logMessage)
        {
            //logic of appending the logMessage to a database;
        }
    }
}