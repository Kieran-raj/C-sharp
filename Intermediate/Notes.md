# Intermediate

## Section 1 and 2

### Classes

#### Declaring classes

```
public class Person
{
    public string Name;

    public void Introduce()
    {
        Console.Writeline("Hi, my name is " + Name)
    }
}
```

<br>

#### Creating Objects

`Person person = new Person()` or `var person = new Person()`

#### Class Members

There are two types of class members:
<br>

&nbsp;&nbsp;&nbsp;&nbsp; - Instance: accessible from an object
<br>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - `var person = new Person()`
<br>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - `person.introduce()`
<br>

&nbsp;&nbsp;&nbsp;&nbsp; - State: accessible from the class
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - Means that an object doesn't have to be created to use it.
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - To represent singletons (there should only be one instance of the class in memory)
<br>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - `Console.Writeline()`

#### Constructors

- Why?
  &nbsp;&nbsp;&nbsp;&nbsp;
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - To put the object in an early state eg setting properties.
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - Don't always need one.

  ```
  public class Customer
  {
    public string Name;

    public Customer(string Name)
    {
        this.Name = name
    }
  }
  ```

- Overloading of constructors is possible

  ```
  public class Customer
  {
      public Customer() { ... }

      public Customer(string name) { ... }

      public Customer(int id, string name) { ... }
  }
  ```

#### Object Initializers

```
var person = new Person
                    {
                        FirstName = "Kieran"
                        LastName = "Smith"
                    }
```

#### Methods

- Overloading methods:
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp; - Methods with the same name buy different signatures
  <br>

```
public class Point
{
  public void Move(int x, int y) { }

  public void Move(Point newLocation) { }

  public void Move(Point newLocation, int speed) { }
}
```

- Params Modifer
  <br>

&nbsp;&nbsp;&nbsp;&nbsp; - If we have `public int Add(int[] numbers) {}`
&nbsp;&nbsp;&nbsp;&nbsp; - We can use "params" -> `public int Add(params int[] numbers) {}`

- Ref modifer
  <br>

  ```
  public class MyClass
  {
    public void MyMethod(int a)
    {
      a += 2;
    }
  }

  var a = 1;
  myClass.MyMethod(a)
  ```

  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - Above `a` would actually be 1 because within the class a is a local copy
  <br>
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - We can fix this by adding `ref` to both the method definition and method call.

- Out Modifer
  <br>

  ```
  public class MyClass
  {
    public void MyMethod(out int result)
    {
      result = 1;
    }
  }

  int a;
  myClass.MyMethod(out a);
  ```
