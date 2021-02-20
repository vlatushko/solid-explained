## Single Responsibility Principle Explained

### Structure
This example has the following structure:
* Violation
    * TooLittleSeparation
    * TooMuchSeparation 
* CorrectUsage
* SRPExample.cs (shows usage of services from each approach)

### Each example explained
#### Violation
##### Too Little Separation
In this example, you can see, that the single class `LoggingService` has all logic in one place. It has implementation of logging to a file
or to a database.

Having everything in one class leads to the following problems:
* There potentially will be too much dependencies on this class in a big project;
* You have several reasons to change the class, which may lead to errors;
* Additional state adds more complexity to managing the class, just imagine how the class would look like if you were to be logging to 10 different types of storage...;
* This class is hard to unit test;

The only advantage of such an approach I can see is that it's easy to understand what this class does. Although, it's only in case
this class is short. When it becomes big - it will be hard to orient in the forest of state flags.

##### Too Much Separation

As you can see in the folder, there are 5 classes and 5 interfaces separated by functions (Log warning, log error etc.).

Let's see what pros and cons this approach has.

**Pros:**
* The classes are small and easy to understand in isolation;
* The classes are easy to maintain;

**Cons:**
* Using those classes is cumbersome because if you need to log all types you would need to inject all the intefaces (`IInfoLoggingService`, `IWarningLoggingService` and `IErrorLoggingService`);
* Having to setup the Dependency Injection for these classes will take more time;
* Adding new features to logging in general involves editing more classes;
* Creating all of those classes felt dummy for me;
* It simply inconvenient to work with such amount of classes as you need to have them all open;
* If a feature is pretty big - it becomes hard to create a mental picture of how it works in general;
* It forces to duplicate some common logic or creating another additional base class for it;
* You still need some state for the Logging Service (moreover the same state for all of the services);

#### Correct Usage

As you may notice, we still needed to create 8 files in general (4 interfaces and 4 classes). It may look as if we separate it too much, but let's evaluate pros and cons of this approach.

**Pros:**
* You don't need any state in the `LoggingService` class;
* Instead of injecting three different logging services (`IInfoLoggingService`, `IWarningLoggingService` and `IErrorLoggingService`) you inject the single `ILoggingService` interface
* Where to store the logs is now a responsibility of a config class, we just inject the `ILogger` interface for the `ILoggerService` and that's it!
* All related logic is in the same class (`LogInfo()`, `LogWarning()` and `LogError()` methods are all in the same place);
* You can add new types of loggers without modifying any of the existing classes. For instance, if we needed to create logger to Elastisearch we would create two files: interface `IElasticsearchLogger` and class `ElasticSearchLogger` that implements it, then just configure where to log somewhere in a configurator!
* Different developers can work on each type of logger;
* It's easy to Unit Test all of the classes here

**Cons:**
* Requires to add 8 (in this example) files in total;

### Conclusion
As you may notice, everything in this world should be in balance.

Too little separation of concerns (SOC) requires more efforts and branching logic to work correctly.

Too much SOC requires more effort to create a lot of different files, still requires storing some state in the services and is hard to understand in case with big services.

The correct usage example still requires many files to create, but has explicit advantages in usage and maintainability of the system.

P.S. If you notice any mistakes or I have explained something incorrectly - please, feel free to comment, I would be happy to discuss and understand my mistakes!