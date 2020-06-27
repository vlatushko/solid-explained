## Single Responsibility Principle Explained

### Structure
This example has the following structure:
* Violation
    * TooLittleSeparation
    * TooMuchSeparation 
* CorrectUsage
    * to be added...

### Each example explained
#### Violation
##### Too Little Separation
In this example, you can see, that the single class `LoggingService` has all logic in one place. It has implementation of logging to a file
or to a database.

Having everything in one class leads to the following problems:
* There potentially will be too much dependencies on this class in a big project;
* You have several reasons to change the class, which may lead to errors;
* Additional state add more complexity to managing the class, just imagine how the class would look like if you were to be logging to 10 different types of storage...;
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
* Adding new features to loggin in general involves editing more classes;
* Creating all of those classes felt dummy for me;
* It simply inconvenient to work with such amount of classes as you need to have the open;
* If a feature is pretty big - it becomes hard to create a mental picture of how it works in general;
* It forces to duplicate some common logic or creating another additional base class for it;

