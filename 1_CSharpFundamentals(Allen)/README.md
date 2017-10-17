# C# Fundamentals

## .NET

- .NET is a software framework
- our applications run on top of the .NET Framework
- our programs can take advantage of services and interfaces provided by the framework.

### Two distinct pieces:

  1. Common Language Runtime (CLR)
  2. Framework Class Library (FCL)

## The Common Language Runtime (CLR)

- execution environment for .NET applications, including applications written in C#
- brings application to life and manages it while it executes
- also, tears down the application when it's finished executing or if it has an unrecoverable error.
 
### Services provided by the CLR:

  1. **Memory management** - tracks all of the memory that your program uses to do work, and cleans it up as needed.

  2. **Virtualizes the execution environment** - you don't need to worry about what version of the OS your application is operating on (for the most part), you don't need to worry about the specific CPU or if it is 32-bit or 64-bit, or how many cores, or what instruction set.

  3. **Multiple languages** - C# is the major one, but you can also write in VB or F#

## The Framework Class Library (FCL)

- works in the background to manage your application while it is running
- contains reusable software, used to build applications
- Base Class Library (BCL) - subset of the FCL (works everywhere)

## The C# Language

- one of many languages for .NET
- syntax is similar to Java, C++, and JavaScript

```c#
using System;

public class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine(DateTime.Now.DayOfWeek);
    }
}
```

## The Compiler

- file.cs    -->        csc.exe
- usually, you're not compiling a single file
- you're telling the compiler about multiple files in multiple directories(using Visual Studio) and the compilers compiles the file to a single file.
- The compiler transforms the code into Microsoft Intermediate Language (MSIL)
- MISL defines instructions for the CLR

## Debugging

### Syntax Error

- easier problems to fix because VS will warn or you compiler will tell you a more specific error.
- double-clicking on an error in Visual Studio will take you to the error.

### Run-time Error

- no syntax errors, but code does not behave as expected when run.
- harder to diagnose.
- this is when the debuggers is useful.
- step through code line-by-line
- allows you to set breakpoints on a specific line of code

- Autos window - shows you some of the variables that are available in the current context where you're debugging.

- Step into - steps into method
- Step over - steps over method

- IndexOutOfRangeException

## Are you sleepy?

```c#
using System;

namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Your name:");
            string name = Console.ReadLine();

            Console.WriteLine("How many hours of sleep did you get last night?");
            int hoursOfSleep - int.Parse(Console.ReadLine());

            Console.WriteLine("Hello, " + name);

            if (hoursOfSleep > 8)
            {
                Console.WriteLine("You are well rested.");
            } 
            else
            {
                Console.WriteLine("You need more sleep.");
            }
        }
    }
}
```

## Classes and Objects

- classes allow us to model the world around us in software
- we generally use classes to create models for the different nouns that
we need to work with
- class members define:
1. State (properties)
2. Behavior (methods)

### The Grade Book

We need an electronic grade book to read the scores of an individual student
and then compute some simple statistics from the scores.

The grades are entered as floating point numbers from 0 to 100, and the 
statistics should show us the highest grade, the lowest grade, and the
average score.

**GradeBook State**
1. The grades for a user

**GradeBook Behavior**
1. Add a new grade
2. Calculate statistics

Program.cs
```c#
namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(stats.AverageGrade);
            Console.WriteLine(stats.HighestGrade);
            Console.WriteLine(stats.LowestGrade);
        }
    }
}
```

GradeBook.cs
```c#
System.Collections.Generic;

namespace Grades
{
    class GradeBook
    {
        //  Fields
        private List<float> grades;

        //  Constructors
        public GradeBook()
        {
            grades = new List<float>();
        }

        //  Methods
        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats =  new GradeStatistics();

            float sum = 0;

            foreach(float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;

            return stats;
        }
    }
}
```

GradeStatistics.cs
```c#
namespace Grades
{
    class GradeStatistics 
    {
        public float AverageGrade;
        public float HighestGrade;
        public float LowestGrade;

        public GradeStatistics()
        {
            HighestGrade = 0;
            LowestGrade = float.MaxValue;
        }
    }
}
```

## Constructors

- Special methods used to initialize objects

new Class() intializes a new object - the () is the call to the constructor.

- If you don't define your own constructor, an implicit one will be provided

- code snippet: ctor

- Writing your own constructor gives you control over the initialization of an object
  - you can initialize field and data
  - set default values
  - create other objects that your object uses

```c#
GradeBook book = new GradeBook();
```

```c#
public GradeBook()
{
    // 
}
```

## Classes vs. Variables

- A class is a **blueprint** for creating objects
- A class can also be used to type a variable
- A variable is a storage location that points to a specific object

- When a variable pointing to an object changes to point to a new one,
    the CLR garbage collects.

## Reference Types
- classes are reference types
- variables hold a pointer value

```c#
GradeBook book1 = new GradeBook();
```

- book1 holds a pointer to the memory location of the new GradeBook
- it doesn't hold the value in the memory location itself

```c#
GradeBook book2 = book1;
```

- book2 now points to the same memory location as book1

```c#
GradeBook book = new GradeBook();
book.AddGrade(91);
book.AddGrade(89.5f);

GradeBook book2 = book;
book2.AddGrade(75)
```

- book now has three values - 91, 89.5, and 75

## Access Modifiers

- **Encapsulation** - enclosing or hiding details

- Public access modifier makes the class member available OUTSIDE the class

- if no modifier is explicitly set, the default is to make it private

- Private access modifier makes the class member available only INSIDE the class

- Internal modifier makes a class only available inside of the project / assembly(default for classes)

## Static

- Use static members of a class without creating an instance

```c#
public static float MinimumGrade = 0;
public static float MaximumGrade = 100;
```

- outside of the class, you can then import it with:

```c#
GradeBook.MaximumGrade      // returns 100
```

Another example:
```c#
Console.WriteLine("Hello!");
```

- You don't have to invoke an instance of the Console class to use its method (WriteLine())

## Assemblies

- Assemblies are the files the C# compiler creates for us
- Nearly impossible to write a C# program with just one assembly 
- We will learn how to build assemblies and reference other assemblies from .NET framework and third-party assemblies
- We'll also learn how to write unit tests

### csc.exe

- The compiler is csc.exe and one or more source files can be passed to it, producing an executable (assembly).
- Assemblies are .exe or .dll files
  - .exe is a file you can execute directly by double clicking or using the name of the program from the command line
  - .dll (Dynamic-Link Library) is a file that you cannot execute directly (another program can load it and use the code inside)
      - for when you are writing code that you want to reuse in multiple locations
      - ex) MSCorLib.dll - a core library that contains the core types of the .NET framework
      - Global Assembly Cache (ex. C:\Windows\assembly\GAC)

### Browsing Assemblies

- When you build your solution, all of your files are built into an assembly. 
  - by default, it goes into your \bin\Debug directory in your project folder

- Right click Solution > Properties > Application tab
  - Assembly name
  - Output type setting (select Windows application, console application, class library)

- Whenever you're using a class from the .NET Framework (or another third-party assembly)
  - Cursor on class + F12 opens a window with what looks like the source code of that class
  - not full source clode, VS just shows you what is available on the class
  - at the top, it shows you what assembly it lives it (Assembly mscorlib, version 4.0.0.0)

- Can also open the references node in the Solution Explorer
  - MSCorLib is not listed (such an essential library that it is implied you'll be using it)

- Can also view what is available inside of the assemblies in the Object Browser

### Referencing Assemblies

- Must load assembly into memory before using types inside

- Right click > Add reference

```c#
using System.Speech.Synthesis;

class Program
{
    static void Main(string[] args)
    {
        SpeechSynthesizer synth = new SpeechSynthesizer();
        synth.Speak("Hello! This is my program!");
    }
}
```

## Introduction to Unit Testing

- Write code to test code!
- Write some code to test your C# code in an automatic manner
- Pluralsight has other courses that cover unit testing in more detail
- Visual Studio provides a special project type dedicated to unit test code.

- The unit test project produces an assembly with my test code
- The test assembly typically has to reference another assembly with code to be tested



- [TestClass] and [TestMethod] are attributes

- **attributes** - a piece of data that is associated with a class or a method

- TestRunner will find all of your Test classes, instantiate each one, and execute the methods inside, and then determine if a method passes or fails

- If no error occurs inside of a test method, the TestRunner will assume that the test passed

- Assert class is used to make assertions about a particular piece of data or a particular facet of the program.

  - if assertions don't hold true, they will raise an error

```c#
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grades;

namespace Grades.Tests
{
    [TestClass]
    public class GradeBookTests
    {
        [TestMethod]
        public void ComputesHighestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);

            GradeStatistics result = book.ComputeStatistics();

            Assert.AreEqual(90, result.HighestGrade);
        }

        [TestMethod]
        public void ComputesLowestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);

            GradeStatistics result = book.ComputeStatistics();

            Assert.AreEqual(10, result.LowestGrade);
        }

        [TestMethod]
        public void ComputesAverageGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics result = book.ComputeStatistics();

            //  Floats are difficult to unit test - third argument to specify amount of precision error
            Assert.AreEqual(85.16, result.AverageGrade, 0.01);
        }
    }
}
```

## Types

- Important to know that every type falls into one of two categories

  1. Reference Type

  2. Value Type

### Reference Types

- Created from class definitions
- Anytime I create a new class, I'm creating a new reference type
- Holds a reference or a pointer to a memory location
- Can have multiple variables pointing to the exact same object instance

```c#
GradeBook g1 = new GradeBook();
GradeBook g2 = g1;

g1.Name = "Scott's grade book";
Console.WriteLine(g2.Name);         //  --> Scott's grade book
```

```c#
GradeBook g1 = new GradeBook();
GradeBook g2 = g1;

g1 = new GradeBook();
g1.Name = "Scott's grade book";
Console.WriteLine(g2.Name);         //  --> Nothing - name hasn't been assigned
```

### Value Types

- Does not hold a memory address, holds a value itself
- Faster to allocate memory than reference types (creating object is more expensive)
- Many built-in primitive types are value types
  - int
  - double
  - float
  - etc.

- Value types are typically immutable

```c#
int x1 = 100;
int x2 = x1;

x1 = 4;

Console.WriteLine(x1);          //  --> 4
Console.WriteLine(x2);          //  --> 100
```

### Creating Value Types

#### 1. Structs
- struct definitions create value types

```c#
public struct DateTime
{
    // ...
}
```

##### When to use struct
- generally, you want to write a class by default
- structs are used for special cases when you need to write an abstraction that represents a single value
- structs should be small

#### 2. Enumerations
- an enum creates a value type

```c#
public enum PayrollType
{
    Contractor = 1,
    Salaried, 
    Executive,
    Hourly
}
```

- an enum creates a type that will hold specific numerical values
- a good way to create named constants in your software
- can help eliminate "magic numbers"
  ```c#
  if (employee.Role == PayrollType.Hourly)
  {
      // ...
  }
  ```   

  - by default, the first value of an enum is 0
  - but, you can specifically assign values to make it more readable or logical

### Method Parameters

- In C#, the default is to pass parameters by value
  - When you call a method that takes a parameter, by default the value in the variable
    you pass will be copied into the variable that is a parameter to the method
  - what you pass is **always** a copy **unless** you add some additional keywords (rarely used)

- For reference type variables, this means you are **passing a copy of a reference**
- When you pass a value type variable to a method - you are **passing a copy of the value held by variable**

```c#
public void DoWork(GradeBook book)
{
    book.Name = "Grades";
}
```

- the method above gets a **copy** of the pointer to a GradeBook
  - so, both the calling code and the method that is being called have pointers to the same object
  - has profound implications for what happens inside of the method and what changes I can see when method exits

```c#
GradeBook book1 = new GradeBook();
GradeBook book2 = book1;

GiveBookAName(book2);
```

```c#
public void GiveBookAName(GradeBook book)
{
    book.Name = "A GradeBook";
}
```

- in the above example, all three variables (book1, book2, and the parameter book) all point to the same memory location

### Immutability

- Value types are usually immutable
  - **Once you create a value, you cannot change the value**
  - That doesn't mean the value stored in a variable cannot change

```c#
DateTime date = new DateTime(2002, 8, 11);
date.AddDays(1)

string name = " Scott";
name.Trim();
```

- The above are errors new C# programmers often make:
  - You cannot reassign the value in the variable
  - even though the DateTime object has a method AddDays() and a string has the method Trim()
  - Instead what happens here is it returns a new DateTime instance, so you need to assign the new value to a variable to store it
  - Trim() does not modify the string passed to it - it returns a new string with whitespace removed

**DOESN'T WORK:**
```c#
DateTime date = new DateTime(2015, 1, 1);
date.AddDays(1);
```

**WORKS:**
```c#
DateTime date = new DateTime(2015, 1, 1);
date = date.AddDays(1);
```

### Arrays and Lists

- Manage a collection of variables (always a reference type)
- Arrays have a fixed size, changing the size can be expensive
- The size of a List **can** change
- Bot Arrays and Lists are 0 indexed

```c#
const int numberOfStudents = 4;
int[] scores = new int[numberOfStudents];

int totalScore = 0;
foreach(int score in scores)
{
    totalScore += score;
}

double averageScore = (double)totalScore / scores.Length;
```

## Methods, Fields and Properties

- Members you can attach to a type

### Methods

- Methods define behavior

- Every method has an access modifier

  - **private** (default) - only available to other code inside the same class
  - **internal** - only available to code inside of the same project
  - **public** - available everywhere

- Every method has a return type
  - **void** means the method doesn't return a value to the caller

- Every method has a name

- Every method has 0 or more parameters
  - Use params keyword to accept a variable number of parameters
    - not something you use regularly, but extremely powerful in the right scenario

- Every method has a **method signature**
  - unique identifier for a method
  - (name) + (# and types of parameters)
  - return type of a method is **not** part of the method signature
  - ex: 
    - WriteAsBytes(int value)
    - WriteAsBytes(string word)
    - two different methods and I can have both in my class

```c#
public void WriteAsBytes(int value)
{
    byte[] bytes = BitConverter.GetBytes(value);

    foreach(byte b in bytes)
    {
        Console.WriteLine("0x{0:X2} ", b);
    }
}
```

#### method overloading 
- can have as many methods with the same name as you need, as long as the parameter list is different

```c#
static void Main(string[] args)
        {
            GradeBook book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
        }

static void WriteResult(string description, int result) => Console.WriteLine($"{description}: {result}");

static void WriteResult(string description, float result) => Console.WriteLine($"{description}: {result:F2}");
```

### Fields

- Fields are variables of a class
- They define the state or the data that you want to hold as part of an object
- Usually fields are made private and the name is lowercase with an underscore
- A readonly field means that it can only be assigned in the constructor or when the field is defined with a field initializer

```c#
public class Animal
{
    private readonly string _name;      //  private field

    public Animal(string name)
    {
        _name = name;
    }
}
```

### Properties

- A property is similar to a field because it controls state and data associated wtih an object
- Unlike a field, a property has a special syntax we can use to control what happens when someone reads or writes the data
  - **get or set accessors**
  - able to do logic or validation with data inputs or reads
  - whatever value someone is trying to read or write is implicitly passed as "value" (think of it almost like a parameter)

```c#
public class Animal
{
    private string _name;

    public string Name
    {
        get { return _name; }
        set
        {
            if (!String.IsNullOrEmpty(value))
            {
                _name = value;                  //  value is implictly passed
            }
        }
    }
}
```

#### Auto-implemented properties

- have the keywords get and set inside with semicolons after each, and there's no curly braces or code
- behind the scenes, the C# compiler will automatically create a field to store the value for this property
- it will automatically read that field during a get operation and write to the field during a set operation


```c#
public string Name
{
    get; 
    set;
}
```

### Fields vs. Properties

- To the user, they are the same. 

- However, there are some parts of the .NET Framework and other frameworks that treat fiels and properties differently

- Often if you are performing serialization (taking an object and serializing it to XML, JSON, or saving it to a database)

  - some frameworks only look at properties when they do the serialization

- There are also data binding features in the .NET framework (assigning an object to some part of your user interface)
  
  - some data binding features will only move properties, they won't look at fields

- **In general, if you're going to make the member publically available, use a property instead of a field**

### Events

- Allow a class to send notifications to other classes or objects
- To keep track of components that do interesting things at unpredictable times.
- The **publisher** raises the event
- One or more **subscribers** process the event
- The beauty of of events is the publisher doesn't need to keep track of who is subscribing and the subscribers don't need to know about each other
  - **this is done through the magic of delegates in C#**

### Delegates

- Imagine needing to declare a variable that references as a method (instead of an integer, string, class object etc.)
  - a method that encapsulates executable code
  - you can then invoke the variable like you would invoke a method by using parentheses and optionally passing some parameters along.

- In order for this to work, you'll need to create a delegate type

- **delegate** - a type that references methods

- The type definition looks almost like a method definition, describes the methods that I want to call.

```c#
public delegate void Writer(string message);
```

- A variable of the type above will point to a method that returns void and takes a string parameter
- There are no curly braces - I'm not defining a method with executable code
- Defining a type that I can use to create variables and point those variables to methods that have this signature and return type

```c#
public class Logger
{
    public void WriteMessage(String message)
    {
        Console.WriteLine(message);
    }
}
```

- Once I have the Logger class, I can instantiate a Logger
- After instantiating a Logger, I can invoke a WriteMessage() method and have the Logger do something interesting like a print a message to the screen

- I can also write a bit of code that instantiates a Logger and then instantiates a delegate that references the WriteMessage method itself of the Logger object

```c#
Logger logger = new Logger();
Writer writer = new Writer(logger.WriteMessage);
writer("Success!");
```

- I'm not invoking logger.WriteMessage - notice that there are no parameters after WriteMessage

- This code is creating a new instance of a delegate and passing the WriteMessage method to this writer delegate
- That delegate is saved into a variable named writer, and I can now invoke logger.WriteMessage just by invoking this variable
- All I need to do is apply parentheses to the variable and pass along the string parameter that I want to Logger to use

NameChangedDelegate.cs
```c#
public delegate void NameChangedDelegate(string existingName, string newName);
```

GradeBook.cs
```c#
public string Name
{
    get
    {
        return _name;
    }
    set
    {
        if (!String.IsNullOrEmpty(value))
        {
            if (_name != value)             //  Name changed
            {
                NameChanged(_name, value)   //  Invoke NameChangedDelegate
            }
            _name = value;                  //  Name now equals the value implicitly passed
        }
    }
}

public NameChangedDelegate NameChanged;
```

Program.cs
```c#
static void main(string[] args)
{
    GradeBook book = new GradeBook();

    book.NameChanged = new NameChangedDelegate(OnNameChanged);      //  Invoke the delegate - method will be called when name changes
}

//  Define the method that will run when name changed
static void OnNameChanged(string existingName, string newName) => Console.WriteLine($"Grade book changing from {existingName} to {newName}");       
```

- Add delegates with += operator:

```c#
book.NameChanged += new NameChangedDelegate(OnNameChanged);
book.NameChanged += new NameChangedDelegate(OnNameChanged2);
```

- Remove delegate from the event with -= operator

### Events Revisited

- Once you understand how delegates work, it's very easy to understand events
- Events are based on and use delegates

- The only thing I need to do to make the delegate from the previous example into a delegate is to add the C# event keyword:

GradeBook.cs
```c#
public event NameChangedDelegate NameChanged;
```

- Now, from outside the GradeBook, the only other thing that other pieces of code can do is add a subscriber (+=) or remove a subscriber (-=)
- Previously, with just delegates, it would be possible to do an assignment and set it to null: book.NameChanged = null;
  - Using events prevents this
  - We want independent pieces of code to be able to subscribe and unsubscribe and not interfere with others

- Adding a subscriber in previous example is now a bit verbose
- You can remove the instantiation of new NameChangedDelegates (the C# compiler will instantiate it behind the scenees):

```c#
book.NameChanged += OnNameChanged;
book.NameChanged += OnNameChanged2;
```

- We are breaking a .NET convention by passing in two string parameters in the above delegate
- **CONVENTION**: An event always passes along two parameters: 
  1. The first parameter is going to be the sender of the event (ex. GradeBook)
  2. The second parameter contains all of the arguments or all of the needed information about that event
    - Need to build another object to pass the existingName and newName so I can pass that object along as the arguments
  3. The class that is passed as an object containing the data ends in EventArgs (ex. NameChangedEventArgs) and inherit from EventArgs

NameChangedEventArgs.cs
```c#
public class NameChangedEventArgs : EventArgs
{
    public string ExistingName { get; set; }
    public string NewName {get; set;}
}
```  

NameChangedDelegate.cs
```c#
public delegate void NameChangedDelegate(object sender, NameChangedEventArgs args);
```

GradeBook.cs
```c#
public string Name
{
    get
    {
        return _name;
    }
    set
    {
        if (!String.IsNullOrEmpty(value))
        {
            if (_name != value)
            {
                NameChangedEventArgs args = new NameChangedEventArgs();     //  Instantiate
                args.ExistingName = _name;                                  //  Current value
                args.NewName = value;                                       //  Value implicitly passed

                NameChanged(this, args);                                    //  this = this GradeBook instance
            }
            _name = value;
        }
    }
}
```

Program.cs
```c#
static void Main(string[] args)
{
    GradeBook book = new GradeBook()

    book.NameChanged = OnNameChanged;
}

static void OnNameChanged(object sender, NameChangedEventArgs args) => Console.WriteLine($"Grade book changing from {args.ExistingName} to {args.NewName}");
```

## Control Flow

### Branching

#### If Statement
- The if statement selects a statement for execution based on the value of a boolean expression
- You don't have to use curly braces to execute single statements, but it's considered good practice (easier to maintain, somewhat more readable)
- You must use curly braces to execute multiple statements

```c#
if (age <= 2)
    ServeMilk();
else if (age < 21)
    ServeSoda();
else 
    ServeDrink();
```

- It's also possible to nest if statements
- Be careful not to nest too many statements for readability

```c#
if (age <= 2)
{
    if (name == "Scott")
    {
        //  ...
    }
}
```
#### Conditional / Ternary Operator

```c#
string pass = age > 20 ? "pass" : "nopass";
```

Called a ternary operator because it has **three parts**:
  1. boolean expression (age > 20)
  2. return statement if true ("pass")
  3. return statement if false ("nopass")

#### Switching

- branch execution of a program to a set of statements that are inside of a case label

- must add a break statement to get out of switch statement

- Restricted to integers, characters, strings, and enums
  - Case labels are constant
  - Default label is optional

```c#
switch(name) {
    case "Scott":
        ServeSoda();
        break;
    case "Alex":
        ServeMilk();
        ServeDrink();
        break;
    default:
        ServeMilk();
        break;
}
```

### Iterating

Four statements for iterating in C#:
  1. foreach
  ```c#
  int[] ages = { 2, 21, 40, 72, 100 }
  foreach (int value in ages)
  {
      Console.WriteLine(value);
  }
  ```
  2. for
  ```c#
  for (int i = 0; i < age; i++)
  {
      Console.WriteLine(i);
  }
  ```
  3. while
  ```c#
  while (age > 0)
  {
      age -= 1;
      Console.WriteLine(age);
  }
  ```
  4. do while
  ```c#
  do 
  {
      age ++;
      Console.WriteLine(age);
  } while (age < 100);
  ```

### Jumping

#### break
  - break out of a loop (or switch statement) and stop looping

#### continue
  - skip executing any code after the continue statement and go to the next iteration

```c#
foreach (int age in ages)
{
    if (age == 2) 
    {
        continue;
    }
    if (age == 21)
    {
        break;
    }
}
```

#### goto
  - jump to another statement that is marked by a label
  - most programmers avoid using at all costs

#### return
  - worth noting that you can use a return statement in a void method
  - (just not allowed to pass a value back to the caller)

  - in the following code, if we encounter an age = 21, we'll not only break out of the loop, but break out of the method itself:
  ```c#
  void CheckAges()
  {
      foreach (int age in ComputeAges())
      {
          if (age == 21) return;
      }
  }
  ```

#### throw
  - exceptions

### Throwing

- Use throw to raise an exception

- exceptions provide safe and structured error handling in .NET

- use exceptions when the program finds itself in a situation where it cannot move forward
  - bad input value
  - program out of memory
  - network not available
  - etc.

- When you throw an exception, you are throwing an **object**

- An unhandled exception will terminate your program

```c#
if (age == 21)
{
    throw new ArgumentException("21 is not a legal value");
}
```

### Handling Exceptions

- Handle exceptions by using a try block

- Inside of the try block, execute code that may throw an exception

- The try block can by followed by one or more catch statements

- Runtime will search for the closest matching catch statement

```c#
try
{
    ComputeStatistics();
}
catch(DivideByZeroException ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.StackTrace);
}
```

### Chaining Catch Blocks

- Place most specific type in the first catch clause

- The first exception that specifies a matching exception type will be the catch block executed

- Catching a System.Exception catches everything
  - (except a few "special" exceptions)

- If the general "Exception" was above the DivideByZero exception, the DivideByZero exception would never run
```c#
try {
    //  ...
}
catch(DivideByZeroException ex)
{
    //  ...
}
catch(Exception ex)
{
    //  ...
}
```

### Finally

- Finally clause adds finalization code - allows you specify a block of code that is always going to execute, even if there is an exception inside of the try block

- Executes even when control jumps out of scope


```c#
FileStream file = new FileStream("file.txt", FileMode.Open);
try
{
}
finally
{
    file.Close();
}
```

- using statement: I'm going to be using this unmanaged resource (ex. StreamWriter) in the following block of code.
- curly braces to contain all of the code that will be using that resource
- you then don't have to explicity close the stream

```c#
using (StreamWriter outputFile = File.CreateText("grades.txt"))
{
    book.WriteGrades(outputFile);
}
```

## Object Oriented Programming

## The Pillars

Three pillars of object oriented programming:

  1. Encapsulation
    - primary pillar of OOP
    - without encapsulation, we could never build large applications or large systems
    - helps us hide complexity
    - hiding complexity and building models, which logically group together functionality.
    - Inheritance and polymorphism are more about reusing code and reusing data

  2. Inheritance
    
  3. Polymorphism

## Inheritance
  - a technique to define a relationship between two classes such that one class take on, or inherits, the members of another class
  - the syntax is to have a colon after the name of your class, and then you specify the base class
  - you do have to be cautious with inheritance because it does tie up your classes and your code into a tightly bound relationship

  - **base** keyword - reach specific methods in a class that you've inherited from

  - **protected** access modifier allows access for code that is in the class or code that is in a derived class
  ```c#
  public class A
  {
      public void DoWork()
      {
          //  ... work!
      }
  }

  public class B : A
  {

  }

  public class C : B
  {

  }
  ```
## Polymorphism

- Polymorphism = "many shapes"

- One variable can point to different types of objects
  
  - Any time you have a an inheritance relationahip you can have a variable typed as a base class that points to an object derived from that base class

- Objects can behave differently depending on their type

- Everything in C# inherits from System.Object

- **virtual** keyword

```c#
public class A : Object
{
    public virtual void DoWork()
    {
        //  ...
    }
}

public class B : A
{
    public override void DoWork()
    {
        //  optionally call into base...
        base.DoWork();
    }
}
```

## Abstract Classes

  - Abstract classes cannot be instantiated

  - If you derive from Window, but do not provide an instantiation of the Open() method, you've provided another abstract class

  - If you provide an implementation of Open(), you've now created a **concrete** type and you can instatiate it

  - If you can't instantiate an abstract type - why is it useful?
    
    - Because of polymorphism - I can declare a variable of type Window and use that variable to point to any kind of concrete Window tha derives from this abstract type

  ```c#
  public abstract class Window
  {
      public virtual string Title { get; set;}

      public virtual void Draw()
      {
          //    ... drawing code
      }

      public abstract void Open();
  }
  ```

## Interfaces

- Interfaces contain no implementation details (only the signature of methods, events, and properties)

- A type can implement multiple interfaces

```c#
public interface IWindow
{
    string Title { get; set; }
    void Draw();
    void Open();
}
```

## Common Interfaces

## Where to Go Next