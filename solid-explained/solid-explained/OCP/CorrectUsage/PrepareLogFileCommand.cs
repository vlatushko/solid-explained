using System;

namespace solid_explained.OCP.CorrectUsage
{
    public class PrepareLogFileCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("PrepareLog command is executed.");
        }
    }
}