namespace solid_explained.OCP.CorrectUsage
{
    public interface ICommandsFactory
    {
        ICommand CreateCommand(CommandType commandType);
    }
}