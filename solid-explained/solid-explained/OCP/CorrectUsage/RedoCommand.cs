using System;

namespace solid_explained.OCP.CorrectUsage
{
    public class RedoCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Redo command is executed.");
        }
    }
}