# Basics

## Section 1 and 2

### C# vs .NET Framework

- C# is programming language
- .NET is a framework that multiple languages can use (F# and VB.NET)
  <br>
  <br>

#### .NET

- Consists of two Frameworks:
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp;1. CLR (Common Language Runtime)
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp;2. Class Library
  <br>
  <br>

#### CLR

- When compiling C# code it is complued to an Intermediate Language (IL Code) and is independent of hte computer it is running on.
- Need something to convert IL Code to Native Code which is what the CLR does. This is know as **J**ust **I**n **T**ime compiler action or **JIT**.
- As long as machine has CLR it will be able to run the application
  <br>
  <br>

#### High Level Architecture of .NET Apps

- Consists of Classes
- **Namespace** is a container for related classes
- As namespaces grow - an assembly is a container for related namespaces (DLL or EXE)
  <br>
  <br>

## Section 3 Primitive Types and Expressions

### Variables/Constants

- Variable: A name given to a storage location in memory.
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; \* Have to be assigned a value before it can be read.
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; \* Normally Camel Case is used.
- Constant: an immutable value.
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; \* Normally Pascal Case is used.

### Overflowing

- Exceeding the boundary of the data type.
- To stop use the `checked` keyword, which will throw an exception.

### Scope

- Where a varaible / constant has meaning.

### Conversion

- Implicit type conversion
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp;- When a type can be coverted to another without data loss (eg `byte` to `int`)

- Explicit type convertsion (casting)
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - If there is going to be data lost the compiler wont let you do that, so you have to explicitly say that you're aware.

- Conversion between non-compatible types
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - eg string -> number. Can you the `.parse` for all primitive types method or `Convert` class.
  <br>
- `Int.Parse()` VS `Convert.ToInt32()`
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - When a null value is passed through, Int.Parse() will return an ArgumentNullException, but Convert.ToInt32() will return 0
  <br>
  <br>

## Section 4 - Non-primitive Types

### Classes

- When initiating a class, we need allowcate for that object. This is done by using `new` before initiating the class.

- CLR has a process called Garbage Collection which will automatically remove all unused objects.

- Static Modifier:
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - used so then you dont have create an objec to access a static member.
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - this means that the member will only be located once in memory. eg if there are instances of a class with the same method. It will be located 3 times in memory, but static means that it'll be stored only once.
  <br>
  <br>

### Structs

- `struct` keyword used.
- They combine related fields and methods together.
- Use struct when wanting to create a very small lightweight object.
  <br>
  <br>

### Arrays

- A data structure that stores variables of the same type.
- The size of the array needs to be defined when initiating the array and cannot be changed.
- Memory needs to be allocated, so the `new` operator needs to be used.
- Acces using `[]` indexing.
- Short hand declaration - `int[] numbers = new int[3] {1, 2, 3}`
- If no value is set to an element, then it takes the default for that data type, eg int 0, bool false
  <br>
  <br>

### Strings

- String are **immutable**, once created, it cannot be changed
  <br>
  <br>

### Enums

- A set of name/value pairs (constants).
- Used where there a number of related constants.
- Eg:

  ```
  const int RegularAirMail = 1;
  const int RegisteredAirMail = 2;
  const int Express = 3;
  ```

- Can be written:

  ```
  public enum ShippingMethod
  {
    RegularAilMail = 1,
    RegisteredAirMail = 2,
    Express = 3;
  }
  ```

- Internally enum is an integer.
- Best practices would be explicity set the values.
  <br>
  <br>

### Reference Types and Value Types

- Classes and Structures are treated differently at runtime in terms of memory management.
  <br>
  <br>
- Value Types (Structures):
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - When creating a variables of value type allocated on "Stack"
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - The memory allocation is done automatically.
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - When the variables goes out of scope it will immediately get removed from the stack by runtime or CLR.
  <br>
  <br>

- Reference Types (Classes):
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - Programmer needs to allocate memory, `new` operator
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - Memory is allocated on "Heap"
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - Heap is more sustainable, so it'll be kept for a little while even if out of scope.
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - Garbage collected by CLR.
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - Once in a while the CLR will look at the objects, and those that haven't been used in a while will be removed from the heap.
  <br>
  <br>

- When copying one object to a new variable depending on if its a reference of value types, the outcome will be different.

- When you copy a value type to another variable, it is an direct copy, they are independent.

- When you copy a reference type to another variable, the pointer (memory address) of heap
  location copied **NOT** the value.

- Within different scopes, the same named variables will have a different memory location.
  <br>
  <br>

## Section 5 - Control Flow

### If else statements

- Try and avoid multiple nested if statements
  <br>
  <br>

### Iteration Statements

- Do-while loops, the loop is ran once as the condition is not checked till after the first loop.

### Random class

- Random() has some useful methods
  <br>
  <br>

## Section 6 - Arrays and Lists

### Arrays

- There are two types of arrays in C#
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - Recantgular
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - Each row, has the same number of columns
  <br>
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - Jagged
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - The number of columns in each row could be different. This can be seen as an array of arrays

- In C# the CLR is optimized for single dimnesioned arrays
- A reactangle array can be defined like - `var matric = new int[3, 5]`
- A jagged array can be defined like - `var array = new int[3][]`, then `array[0] = new int[4]`
- Arrays are fixed sizes, in that once they are created the size cannot be changed

#### Usefeul Array Methods

- `Array.Clear(Array, start, end)` - Clears the elements of the array. For string, this will set it to 0. For each items it will set the element to null
- `Array.Copy(Array, Target_Array, Number_of_elements)` - Will copy the number of elements to the new array starting from 0

### Lists

- Lists are dynamically sized
- To create - `var numbers = new List<int>();` or `var numbers = new List<int>() {1, 2, 3, 4};`
- Within C# we cannot modify a collection within a `foreach` loop. If you want to remove or modify the collection a simple for loop should be used
- **Should go through Question 2 again on exercises**
  <br>
  <br>

## Section 7 - Working with Dates

### DateTime

- DateTime module is specified within the `System` namespace
- Can be intitated by doing the following:
  &nbsp;&nbsp;&nbsp;&nbsp; - `var dateTime = new DateTime(2015, 1, 1)`
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - To get the current date -> `var now = DateTime.Now`.
  <br>
- DateTime objects are **immutable**
- To modify use the `.Add*()` method ( \* = Days, Months, Years)
- Different methods to convert to strings:
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - `.ToLongDateString(format)`
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - `.ToShortDateString(format)`
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - `.ToLongTimeString(format)`
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - `.ToShortDateString(format)`
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; -`.ToString(format)` ( This includes date and time )
  <br>

### TimeSpan

- Represent a lenght of time
- `var timeSpan = new TimeSpan(1, 2, 3)`
- Has static methods that are more reliable
- If two timeSpans are subtracted the result is a time span
- Has a number of properties:
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - `.Total*` would return the unit plus the extra eg 60 minutes plus 2
- It is **immutable** and has the same `.Add` which takes a TimeSpan
- It has `.toString()` and `TimeSpan.Parse()`

<br>
<br>

### Section 8 - Working with Text

### String

- Formatting:
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - `ToLower()`
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - `ToUpper()`
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - `Trim()`
  <br>

- Searching:
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - `IndexOf("")`
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - `LastIndexOf("")`
  <br>

- Substrings:
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - `Substring(startIndex)`
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - `Substring(startIndex, length)`

- Replacing:
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - `Replace('a', '!')`

- Null Checking:
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - `String.IsNullOrEmpty(str)`
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - `String.IsNullOrWhiteSpace(str)`

- Split:
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - `str.Split(' ')`

- Converting Strings to Numbers:
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - `int.Parse(s)`
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - `Convert.ToInt32(s)` -> NOTE: If s is empty or null, then 0 is returned

- String builder:
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - `var builder = new StringBuilder(**optional starting string**)`
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - Methods:
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - `.Append()`
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - `.AppendLine()`
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - `.Replace()`
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - `.Remove()`
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - `.Insert()`
