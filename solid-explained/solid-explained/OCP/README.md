 ## Open/Closed Principle Explained
 ### Structure
 This example has the following structure:
 * Violation
 * CorrectUsage
    * to be explained...
 ### Each example explained
 #### Violation
 The violation example consists of four classes:
 * `CommandsRunner` (a public interface for some other modules or something...)
 * `PrepareLogFileCommand`
 * `RedoCommand`
 * `UndoCommand`
 
 If you take a look at the `CommandsRunner`, it has a single method `RunCommand(object command)`
 with the switch statement having all types of commands. Each time we need to add a new command to the project
 we will have to modify this method by adding the new case to the switch statement. It violates the Open Closed
 Principle as we modify the class which should be closed to modification and open for extension.
 #### Correct Usage
 To be described...
 ### Conclusion