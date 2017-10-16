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

