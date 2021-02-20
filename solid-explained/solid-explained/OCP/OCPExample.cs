namespace solid_explained.OCP
{
    public class OCPExample
    {
        // fields for violation demo
        private readonly Violation.CommandsRunner _violatedCommandsRunner;

        //fields for correct usage demo
        private readonly CorrectUsage.CommandsRunner _correctCommandsRunner;
        private readonly CorrectUsage.CommandsFactory _commandsFactory;

        public OCPExample()
        {
            //*** This is an example of the OCP violation usage ***

            _violatedCommandsRunner = new Violation.CommandsRunner();

            Undo();
            Redo();
            PrepareLogFile();

            // ****************************************************

            //*** This is an example of the OCP correct usage ***
            _correctCommandsRunner = new CorrectUsage.CommandsRunner();
            _commandsFactory = new CorrectUsage.CommandsFactory();

            var redoCommand = _commandsFactory.CreateCommand(CorrectUsage.CommandType.Redo);
            var undoCommand = _commandsFactory.CreateCommand(CorrectUsage.CommandType.Undo);
            var prepareLogCommand = _commandsFactory.CreateCommand(CorrectUsage.CommandType.PrepareLog);

            _correctCommandsRunner.RunCommand(redoCommand);
            _correctCommandsRunner.RunCommand(undoCommand);
            _correctCommandsRunner.RunCommand(prepareLogCommand);

            // ****************************************************
        }

        //methods for violation demo
        private void Undo()
        {
            Violation.UndoCommand command = new Violation.UndoCommand();
            _violatedCommandsRunner.RunCommand(command);
        }

        private void Redo()
        {
            Violation.RedoCommand command = new Violation.RedoCommand();
            _violatedCommandsRunner.RunCommand(command);
        }

        private void PrepareLogFile()
        {
            Violation.PrepareLogFileCommand command = new Violation.PrepareLogFileCommand();
            _violatedCommandsRunner.RunCommand(command);
        }
    }
}