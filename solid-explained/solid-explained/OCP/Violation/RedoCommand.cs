using System;

namespace solid_explained.OCP.Violation
{
    public class RedoCommand
    {
        public void Execute()
        {
            Console.WriteLine("Redo command executed");
        }
    }
}