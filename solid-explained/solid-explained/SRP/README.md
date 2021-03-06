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
Let's take a look at the `LoggingService.cs` below:
```c#
//At first glimpse, the class looks correct, but actually it has two responsibilities:
// - Log to file
// - Log to database
public class LoggingService : ILoggingService
{
    //as it violates the SRP principle, we need to add some additional state to classes for
    // logic branching depending on setting of the file, which add additional complexity to the class
    private bool _logToFile;
    private bool _logToDatabase;

    public LoggingService(
            bool logToFile,
            bool logToDatabase)
    {
        _logToFile = logToFile;
        _logToDatabase = logToDatabase;
    }

    public void LogInfo(
            string msg)
    {
        Log(msg, LogType.Info);
    }

    public void LogWarning(
            string msg)
    {
        Log(msg, LogType.Warning);
    }

    public void LogError(
            string msg,
            Exception ex)
    {
        Log(msg, LogType.Error, ex);
    }

    private void Log(
            string msg,
            LogType type,
            Exception ex = null)
    {
        if (_logToFile)
            LogToFile(msg, LogType.Info);

        if (_logToDatabase)
            LogToDatabase(msg, LogType.Info);
    }

    //First responsibility
    private void LogToFile(string message, LogType type, Exception ex = null)
    {
        //Log to file logic goes here
    }

    //Second responsibility
    private void LogToDatabase(string message, LogType type, Exception ex = null)
    {
        //Log to database logic goes here
    }
}
```
In this example, you can see, that the single class `LoggingService` has all logic in one place. It has implementation of logging to a file
and to a database.

Having everything in one class leads to the following problems:
* There potentially will be too much dependencies on this class in a big project;
* You have several reasons to change the class, which may lead to errors;
* Additional state adds more complexity to managing the class, just imagine how the class would look like if you were to be logging to 10 different types of storage...;
* This class is hard to unit test;

The only advantage of such an approach I can see is that it's easy to understand what this class does. Although, it's only in case
this class is short. When it becomes big - it will be hard to orient in the forest of state flags.

##### Too Much Separation

Below you can see snippets of 5 classes and 5 interfaces separated by functions (Log warning, log error etc.).

Interfaces:
```c#
public interface IDatabaseLogger
{
    void AppendToDbLog(
            string logMessage);
}
```

```c#
public interface IErrorLoggingService
{
    void Log(
            string message,
            Exception exception);
}
```

```c#
public interface IFileLogger
{
    void AppendToFileLog(
            string logMessage);
}
```

```c#
public interface IInfoLoggingService
{
    void Log(
            string message);
}
```

```c#
public interface IWarningLoggingService
{
    void Log(
            string message);
}
```

Classes:
```c#
public class DatabaseLogger : IDatabaseLogger
{
    public void AppendToDbLog(
            string logMessage)
    {
        //logic of appending the logMessage to a database;
    }
}
```

```c#
public class FileLogger : IFileLogger
{
    public void AppendToFileLog(
            string logMessage)
    {
        //logic of writing the logMessage to a log file;
    }
}
```

```c#
public class ErrorLoggingService : IErrorLoggingService
{
    private readonly IFileLogger _fileLogger;
    private readonly IDatabaseLogger _databaseLogger;

    //requires additional state which makes the usage of the service inconvenient
    private readonly bool _logToFile;
    private readonly bool _logToDb;


    public ErrorLoggingService(
            IFileLogger fileLogger,
            bool logToFile,
            IDatabaseLogger databaseLogger,
            bool logToDb)
    {
        _fileLogger = fileLogger;
        _logToFile = logToFile;

        _databaseLogger = databaseLogger;
        _logToDb = logToDb;
    }

    public void Log(
            string message,
            Exception exception)
    {
        var finalLog = FormatLog(message, exception);

        //this part of code is the same with WarningLogging and InfoLogging services
        //can be refactored out to the base Logging class but it's not our purpose now
        if (_logToFile)
            _fileLogger.AppendToFileLog(finalLog);

        if (_logToDb)
            _databaseLogger.AppendToDbLog(finalLog);
    }

    private string FormatLog(string logMessage, Exception exception)
    {
        //just an example formatting
        return $"LogMessage: {logMessage}, Exception: {exception.Message}";
    }
}
```

```c#
public class InfoLoggingService : IInfoLoggingService
{
    private readonly IFileLogger _fileLogger;
    private readonly IDatabaseLogger _databaseLogger;

    //requires additional state which makes the usage of the service inconvenient
    private readonly bool _logToFile;
    private readonly bool _logToDb;

    public InfoLoggingService(
            IFileLogger fileLogger,
            bool logToFile,
            IDatabaseLogger databaseLogger,
            bool logToDb)
    {
        _fileLogger = fileLogger;
        _logToFile = logToFile;

        _databaseLogger = databaseLogger;
        _logToDb = logToDb;
    }

    public void Log(
            string message)
    {
        if (_logToFile)
            _fileLogger.AppendToFileLog(message);

        if (_logToDb)
            _databaseLogger.AppendToDbLog(message);
    }
}
```

```c#
public class WarningLoggingService : IWarningLoggingService
{
    private readonly IFileLogger _fileLogger;
    private readonly IDatabaseLogger _databaseLogger;

    //requires additional state which makes the usage of the service inconvenient
    private readonly bool _logToFile;
    private readonly bool _logToDb;

    public WarningLoggingService(
            IFileLogger fileLogger,
            bool logToFile,
            IDatabaseLogger databaseLogger,
            bool logToDb)
    {
        _fileLogger = fileLogger;
        _logToFile = logToFile;

        _databaseLogger = databaseLogger;
        _logToDb = logToDb;
    }

    public void Log(
            string message)
    {
        if (_logToFile)
            _fileLogger.AppendToFileLog(message);

        if (_logToDb)
            _databaseLogger.AppendToDbLog(message);
    }
}
```

Let's see what pros and cons this approach has.

**Pros:**
* The classes are small and easy to understand in isolation;
* The classes are easy to maintain (until many of them participate in the same logic);
* The classes are easy to test.

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

As you may notice, we still needed to create 8 files in general (4 interfaces, 3 classes and an enum). Let's take a 
look at each of them:

Interfaces:
```c#
public interface ILoggingService
{
    void LogInfo(
            string message);

    void LogWarning(
            string message);

    void LogError(
            string message,
            Exception exception);
}
```

```c#
public interface ILogger
{
    void Log(
            LogType logType,
            string message,
            Exception exception = null);
}
```

```c#
public interface IFileLogger : ILogger
{

}
```

```c#
public interface IDatabaseLogger : ILogger
{

}
```

Enum:
```c#
public enum LogType
{
    Info,
    Warning,
    Error
}
```

Classes:
```c#
//The classes that will use this logger will need to inject only one interface "ILoggerService"
public class LoggingService : ILoggingService
{
    //as you can see it requires only the base logger interface without
    // worrying where the log should be saved
    private readonly ILogger _logger;

    //NOTE: it DOESN'T require any state for conditional logging!

    public LoggingService(
            ILogger logger)
    {
        _logger = logger;
    }

    public void LogInfo(
            string message)
    {
        _logger.Log(LogType.Info, message);
    }

    public void LogWarning(
            string message)
    {
        _logger.Log(LogType.Warning, message);
    }

    public void LogError(
            string message,
            Exception exception)
    {
        _logger.Log(LogType.Error, message, exception);
    }
}
```

```c#
public class FileLogger : IFileLogger
{
    public void Log(
            LogType logType,
            string message,
            Exception exception = null)
    {
        //log to file logic
    }
}
```

```c#
public class DatabaseLogger : IDatabaseLogger
{
    public void Log(
            LogType logType,
            string message,
            Exception exception = null)
    {
        //logic of saving logs to a database
    }
}
```

It may look as if we separate it too much, but let's evaluate pros and cons of this approach.

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