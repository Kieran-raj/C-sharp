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
