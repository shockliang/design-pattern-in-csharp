# Design Pattern In C# #
Recap design pattern.

## SOLID Design Principles ##
* Introduced by Robert C. Martin.
* Frequently references in Design Pattern literature.

* Single Responsibility Principle
    * A class should only have one reason of change.
    * Separation of concerns - different classes handling different, independent task/problems.

* Open-Closed Principle
    * Classes should be open for extension but closed for modification.

* Liskov Substitution Principle
    * You should be able to substitute a base type for a subtype.

* Interface Segregation Principle
    * Don't put too much into an interface; split into seprate interfaces.
    * YAGNI - You Ain't Going to Need It.

* Dependency Inversion Principle
    * High-level modules should not depend upon low-level ones; use abstractions.

## Builder Pattern ##
* Motivation
    * Some objects are simple and cna be created in a single constructor call.
    * Other objects require a lot of ceremony ot create.
    * Having an object with 10 constructor argument is not productive.
    * Instead, opt for piecewise construction.
    * Builder provides an API for construction an object step-by-step.
* When piecewise object construciont is complicated, provide an API for doing it succinctly.
* A builder is a seprate component for building an object.
* Can either give builder a constructor or return it via a static function.
* To make builder fluent, `return this`.
* Different facets of an object can be built with different builders working in tandem via a base class.

## Factory Pattern ##
* Motivation
    * Object creation logic becomes too convoluted.
    * Constructor is not descriptive.
        * Name mandated by name of containing type.
        * Cannot overload with same sets of arguments with different names.
        * Can turn into 'optional parameter hell'.
    * Object creation (non-piecewise, unlike Builder) can be outsourced to.
        * A separate function (Factory method)
        * That many exist in a separate class (Factory)
        * Can create hierarchy of factories with Abstract Factory.
* A component responsible solely for the wholesale (not piecewise) creation of objects.
* A factory method is a static mehtod that creates objects.
* A factory can take care of object creation.
* A factory can be external or reside inside the object as an inner class.
* Hierarchies of factories can be used to create related objects.

## Prototype Pattern ##
* Motivation
    * Complicated objects (e.g., cars) aren't designed from scratch.
        * They reiterate existing designs.
    * An existing (partially or fully constructed) design is a `Prototype`.
    * We make a copy (clone) the prototype and customize it.
        * Requires 'deep copy' support.
    * We make the cloning convenient (e.g., via a Factory)
* A partially or fully initialized object that you copy (clone) and make use of.
* To implement a prototype, partially construct an object nad store it somewhere.
* Clone the prototype.
    * Implement your won deep copy functionality; or serialize and deserialize.
* Customize the resulting instance.
