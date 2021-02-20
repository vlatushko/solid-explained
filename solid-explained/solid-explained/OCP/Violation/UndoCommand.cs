using System;

namespace solid_explained.OCP.Violation
{
    public class UndoCommand
    {
        public void Execute()
        {
            Console.WriteLine("Undo command executed");
        }
    }
}