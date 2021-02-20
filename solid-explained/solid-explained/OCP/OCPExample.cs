using solid_explained.OCP.Violation;

namespace solid_explained.OCP
{
    public class OCPExample
    {
        private readonly CommandsRunner _commandsRunner;

        public OCPExample()
        {
            _commandsRunner = new CommandsRunner();

            Undo();
            Redo();
            PrepareLogFile();
        }

        private void Undo()
        {
            UndoCommand command = new UndoCommand();
            _commandsRunner.RunCommand(command);
        }

        private void Redo()
        {
            RedoCommand command = new RedoCommand();
            _commandsRunner.RunCommand(command);
        }

        private void PrepareLogFile()
        {
            PrepareLogFileCommand command = new PrepareLogFileCommand();
            _commandsRunner.RunCommand(command);
        }
    }
}