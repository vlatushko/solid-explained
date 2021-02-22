 ## Open/Closed Principle Explained
 ### Structure
 This example has the following structure:
 * Violation
 * CorrectUsage
 
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
 Principle as we modify the class which should be closed for modification and open for extension.
 
 **Pros:**
 * Less files to maintain (only at the beginning)
 * Easier to understand the code (until classes become big)
 * Good for prototypes as is simple to write
 
 **Cons:**
 * Hard to unit test
 * The bigger the project becomes the harder it becomes to understand
 the code.
 * As soon as we modify the public interface (`CommandsRunner`)
 it may introduce new bugs as we modify existing logic
 * If you're developing a library, users will not be able to extend
 the `CommandsRunner` and thus class will be too rigid.
 * It is hard to distribute work on different set of command to different teams
 
 #### Correct Usage
The correct usage example consists of the following files:
* Interfaces
    * `ICommandsRunner`
    * `ICommand`
    * `ICommandsFactory`
* Enums
    * `CommandType`
* Classes
    * `CommandsRunner`
    * `CommandsFactory`
    * `RedoCommand`
    * `UndoCommand`
    * `PrepareLogFileCommand`

In the correct usage example we see three abstractions added (interfaces) which make the
application highly customizable, testable and maintainable. To extend the functionality
of the class we would just need to create a new command (and inherit it from `ICommand`) and then modify only the
`CommandsFactory` and that's it. The `CommandsRunner` would be able to run the newly
added command without modifying it.

**Pros:**
* Unit testing friendly
* Customizable
* The abstractions are untouchable and we're extending application's functionality by creating new commands
* We can separate work on several commands between different teams

**Cons:**
* More work to be done, therefore is more expensive to implement

 ### Conclusion
 Although, when we violate the Open Closed Principle, we need to do less work short term, but it will not work in the long run as will make the application hard to 
 maintain. And not only that, it will also make the `CommandsRunner` class very big and 
 therefore more reasons to change it will appear which, in turn, leads to a higher chance 
 of bugs. We cannot test the application properly, as we don't have abstractions, that's 
 another flaw of violating this principle.
 
 When we apply Open Closed Principle while working on software, it may take more time to 
 implement, but will pay off in the future. Yes, it will require better planning for a developer 
 before starting to work on a feature, but anyway, the code will be more reliable.
 
 P.S. If you see any errors or improvements to my explanation, please, leave comments and let's discuss it ;)