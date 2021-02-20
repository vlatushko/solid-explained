using System;

namespace solid_explained.OCP.CorrectUsage
{
    public class CommandsFactory : ICommandsFactory
    {
        public ICommand CreateCommand(CommandType commandType)
        {
            return commandType switch
            {
                CommandType.Undo => new UndoCommand(),
                CommandType.Redo => new RedoCommand(),
                CommandType.PrepareLog => new PrepareLogFileCommand(),
                _ => throw new ArgumentOutOfRangeException(nameof(commandType), commandType, null)
            };
        }
    }
}