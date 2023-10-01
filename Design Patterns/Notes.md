# C# Design Patterns

---

## Gamma Categorization

Design patterns are usually split into three categories:

&nbsp;&nbsp;&nbsp;&nbsp; - **_Creational Patterns_**

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -> Deal with creation (construction) of objects

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -> Explicit (constructor) vs implicit (DI, reflection, etc)

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -> Wholesale (single statement) vs piecewise (step-by-step)

&nbsp;&nbsp;&nbsp;&nbsp; - **_Structural Patterns_**

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -> Concerned with the structure (eg class members)

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -> Many patterns are wrappers that mimic the underlying class' interface

&nbsp;&nbsp;&nbsp;&nbsp; - **_Behavioral Patterns_**

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -> They are all different, no central theme

---

## Patterns

### 1. Builder

Some objects are simple, others require a lot of ceremony to create. All people to contruct objects piece-by-piece.

A builder provides an API for constructing an object step-by-step.

A "Fluent Builder" allows for the ability to "chain" method after one another eg `builder.Add().Add()`. The `Add` method will simply return the Builder object.

A "Stepwise Builder" will make sure that you can only perform certain steps one after another. You might have a step that needs to occur before another one.

A "Functional Builder" look at code notes.

A "Faceted Builder" sometimes you need several builders that build up different aspects as an object. For example, there might be a `Person` object and it has different categories info, eg company info and address. A builder would be used for each of these categories.

---

### 2. Factories

Similar to builder when object creation becomes convoluted.

Contructor is not descriptive and has limiations:

&nbsp;&nbsp;&nbsp;&nbsp; - Name mandated by the name of the containing type.

&nbsp;&nbsp;&nbsp;&nbsp; - Cannot overload the constructor with the same sets of arguments with different names.

Object creation (non-piecewise, unlike Builder) can be outsourced to:

&nbsp;&nbsp;&nbsp;&nbsp; - A seperate function (**_Factory Method_**)

&nbsp;&nbsp;&nbsp;&nbsp; - That may exist in a separate class (**_Factory_**)

&nbsp;&nbsp;&nbsp;&nbsp; - Can create hierarchy of factories with **_Abstract Factory_**

A **Factory** is a componnent responsible solely for the wholesale creation of objects.

Aync Factory Methods:

&nbsp;&nbsp;&nbsp;&nbsp; - Asynchronos calls cannot be made within the contructor.

&nbsp;&nbsp;&nbsp;&nbsp; - This async call has to be done within an method eg `InitAsync()`. The problem with this is that the method has be called after initialising the class.

&nbsp;&nbsp;&nbsp;&nbsp; - A factory is a component that know how to intialise certain types, this means that the constructors have to be public.

Objects live as long as the factory lives.

Abstrac Ftactory:

&nbsp;&nbsp;&nbsp;&nbsp; - Only real use is to give out abstract objects

&nbsp;&nbsp;&nbsp;&nbsp; - You do not return the types we are creating

### Good to knows

#### Weak Reference:

&nbsp;&nbsp;&nbsp;&nbsp; - **Strong Reference** is a reference to an object where by the _Garbage Collector_ cannot collect an object in use while the app'c code can reach the object.

&nbsp;&nbsp;&nbsp;&nbsp; - **Weak Reference** is a reference to an object where by the _Garbage Collector_ can collect an object while still allowing the app acces to the object

&nbsp;&nbsp;&nbsp;&nbsp; - **Short** Weak References

&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; - When the object is collected the target becomes `null`

&nbsp;&nbsp;&nbsp;&nbsp; - **Long** Weak References

&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; - The reference is retained after the object's `Finalize` method. This allows the object to be recreated but the state is unpredictable

&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; - `True` should be passed into the constructor and if there is no `Finalize` method the short weak reference functionality applies.

**AVOID** using weak referneces for small objects as their pointers could be large or largers.

**AVOID** using weak references as a memory management solution. Instead using an effective caching policy

---

### 3. Prototype

Complicated objects aren't really designed from scratch.

A **Prototype** is an exisitng (paritially or fully construcred) object that you make a copy of and make use of

We make a copy (clone) of the prototype and customise it:

&nbsp;&nbsp;&nbsp;&nbsp; - Requires "deep copy" support, which is copying of the object but also the reference

&nbsp;&nbsp;&nbsp;&nbsp; - Should be convenient to do, eg using a Factory

You **cannot** just do the following

```
var obj = new Object();
var newObj = obj;
newObj[0] = newValue;
```

The above code will modify the same reference make both the old and new objects having the same data values.

There is an Interface called `IClonable` which an object can inherit. The probably is that you would never know if it is a Deep or Shallow (copying the reference) clone. This returns an Object as it was introduced before generics so that is no type checking.

#### Copy Constructors

This is a C++ term , lets you secpify an object to copy all the data from. This copy constructors would be needed at all levels of the object, including any objects within the object.

```
{
    public Person(Person person)
    {
        Name = person.Name;
        Address = new Address(person.Address);
    }

    public Address(Address address)
    {
        Street = address.Street;
        Number = address.Number;
    }
}
```

These are probably not the best way to implement deep cloning, as it is not easily recognised by developers as it is a C++ implementation.

#### Deep Copy Interface

A custom interface can be used so that we can explicity say what the deep copy method should do.

```
{
    public interface IPrototype<T>
    {
        T DeepClone();
    }
}
```

There is still an issue in that if there is an object tree then it gets very tedious for every object to implement this interface.

#### Prototype Inheritance

This can usefull when there inheritance hierarchy gets too large.

#### Copy Serialization

The benefit of doing this is that serializing an deserilizing an object will result in a deep copy anyway.

This can be done using an extension method and using streams. Which means that a class doesn't need to inherit a IProtoype. Example below uses Binary Serialization

```
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);

            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T)copy;
        }
    }
```

**Note** - each class that will be copied will need the `[Serializable]` attribute for Binary Serialization.

**Note** - different serializers will have different requirements in order to serialize.

---

### 4. Singleton

A component that is only instantiated once.

For some components it sometimes makes sense to only have one instance within the system. For example:

&nbsp;&nbsp;&nbsp;&nbsp; - Database repository

&nbsp;&nbsp;&nbsp;&nbsp; - Object factory

Looking at object that the constructor call is expensive.

Provide every consumer with the same instance.

Want to prevent anyone creating additional copies.

Need to take care of lazy instantion and thread safety.

There are different ways to make sure multiple objects aren't getting created:

&nbsp;&nbsp;&nbsp;&nbsp; - Make the constructor private

```
private static SingletonDatabase instance = new SingletonDatabase();

public static SingletonDatabase Instance => instance;
```

This can be improved by make the contruction of the object lazy.

&nbsp;&nbsp;&nbsp;&nbsp; - Make do this because you might not need the object

```
private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());

public static SingletonDatabase Instance => instance.Value;
```

#### Why is it seen as such a bad pattern?

**Testability Issues**
As you soon as you use a Singleton reference somewhere you are hard coding a reference to the instance of that particular component.

This probably can actually be solved using Dependency Injection.

#### Dependency Injection

Instead of build the singleton yourself, you normally delegate the responsibility to DI Container.

When registering something like a database we can do the following:

```
cb.RegisterType<OrdinaryDatabase>().As<IDatabase>().SingleInstance();
```

The `As<IDatabase>()` allows for different database objects to be injected into an object, as long as they implement IDatabase.

The `SingleInstance()` tells the DI container that if someone requests the OrdinaryDatabase it will be given as a singleton.

#### Monostate - If you want a singleton why not make it static?

&nbsp;&nbsp;&nbsp;&nbsp; - A static class doesn't have a constructor, which means you can't you DI

&nbsp;&nbsp;&nbsp;&nbsp; - We can have the state of the an object being static, but exposed in a non static way

```
public class CEO
{
    private static string name;
    private static int age;

    public int Age { get => age; set => age = value; }
    public string Name { get => name; set => name = value; }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
    }
}
```

&nbsp;&nbsp;&nbsp;&nbsp; - You could create a new object, but the properties refer to the same data, because they refer to the static fields.

&nbsp;&nbsp;&nbsp;&nbsp; - This appears to go against singleton as you normally don't call a constructor, but this allow the calling of a constructor

#### Per-Thread Singleton

Instead of having one singleton for a given app domain, it is possible to have a singleton for a single thread.

This avoids thread safety.

#### Ambient Context

This approach is not thread safe, because if there are several threads doing their own thing, they would need separate contexts to work on.

Ambient context should be a singleton, because if there are lots of threads and objects, it might not be very nice.

### 5. Adapter

### 6. Bridge

Simply the concept of connecting different components through abstractions (interface or abstract class).

Motivation:
&nbsp;&nbsp;&nbsp;&nbsp; - Bridge prevents a 'Cartesion product' complexity explosion.

&nbsp;&nbsp;&nbsp;&nbsp; - Avoids entity explosion.

It is a mechanism that decouples an interface (hierachy) from an implementation (hierachy)

### 7 Composite

### 8. Decorator

### 9. Facade
