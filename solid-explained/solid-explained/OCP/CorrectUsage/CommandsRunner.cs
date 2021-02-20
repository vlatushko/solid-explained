using System;

namespace solid_explained.OCP.CorrectUsage
{
    //As you can see, this class doesn't require to be modified to run new commands (closed for modification)
    // and can be extended if necessary (open for extension)
    public class CommandsRunner : ICommandsRunner
    {
        public void RunCommand(ICommand command)
        {
            if (command == null)
                throw new ArgumentNullException($"The {nameof(command)} is null. Terminating...");

            command.Execute();
        }
    }
}