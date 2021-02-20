using System;

namespace solid_explained.OCP.CorrectUsage
{
    public class UndoCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Undo command is executed.");
        }
    }
}