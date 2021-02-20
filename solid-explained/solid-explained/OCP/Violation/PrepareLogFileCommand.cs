using System;

namespace solid_explained.OCP.Violation
{
    public class PrepareLogFileCommand
    {
        public void Execute()
        {
            Console.WriteLine("Prepare log file command executed");
        }
    }
}