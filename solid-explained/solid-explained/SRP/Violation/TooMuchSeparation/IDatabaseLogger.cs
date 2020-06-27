namespace solid_explained.SRP.Violation.TooMuchSeparation
{
    public interface IDatabaseLogger
    {
        void AppendToDbLog(
                string logMessage);
    }
}