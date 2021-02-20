namespace solid_explained.OCP.Violation
{
    //the CommandsRunner class is open for modification (but should be closed)
    // and closed for extension as we wouldn't be able to add a new command
    // without modifying this class
    public class CommandsRunner
    {
        //each time you add a new command - you need to modify this method
        public void RunCommand(object command)
        {
            if (command is UndoCommand undoCommand)
                undoCommand.Execute();
            else if(command is RedoCommand redoCommand)
                redoCommand.Execute();
            else if(command is PrepareLogFileCommand prepareLogFileCommand)
                prepareLogFileCommand.Execute();
        }
    }
}