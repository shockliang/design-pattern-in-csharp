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

## Singleton Pattern ##
* Motivation
    * For some components it only makes sense to have one in the system.
        * Database repository.
        * Object factory.
    * E.g., the constructor call is expensive.
        * We only do it once.
        * We provide everyone with the same instance.
    * Want to prevent anyone creating additional copies.
    * Need to take care of lazy instantiation and thread safety.
* A component which is instantiated only once.
* Making a 'safe' singleton is easy:
    * Constrct a static `Lazy<T>` and return its value;
* Singletons ard difficult to test.
* Instead of directly using a singleton, consider depending on an abstraction(e.g., an interface)
* Consider difining singleton lifetime in DI container.

## Adapter Pattern ##
* Motivation
    * A construct which adapts an existing interface X to conform to the required interface Y.
* Implementing an Adapter is easy.
* Determine the API you have and the API you need.
* Create a component which aggregates (has a reference to,....) the adapter.
* Intermediate representations can pile up: use caching and other optimizations.

## Bridge Pattern ##
* Motivation
    * Bridge prvents a 'Cartesian product' complexity explosion
    * Example:
        * Base class ThreadScheduler.
        * Can be preemptive or cooperative.
        * Can run on Windows or Unix.
        * End up with with a 2x2 scenario: WindowsPTS, UnixPTS, WindowsCTS, UnixCTS.
    * Bridge pattern avoids the entity explosion.
* A mechanism that decouples an interface (hierarchy) from an implementation (hierarchy). 
* Decouple abstraction from implementation.
* Both can exist as hierarchies.
* A stronger form of encapsulation.

## Composite Pattern ##
* Motivation
    * Objects use other object's fields/properties/members through inheritance and composition.
    * Composition lets us make compound objects.
        * A mathematical expression composed of simple expressions.
        * A grouping of shapes that consists of several shapes.
    * Composite design pattern is used to treat both single (scalar) and composite objects uniformly.
        * `Foo` and `Collection<Foo>` have common APIs.
* A mechanism for treating individual (scalar) objects and compositions of objects in a uniform manner.
* Objects can use other objects via inheritance/composition.
* Some composed and singular objects need similar/identical behaviors.
* Composite design pattern lets us treat both types of objects uniformly.
* C# has special support for the enumeration concept.
* A single object can masquerade as collection with `yield return this`.

## Decorator Pattern ##
* Motivation
    * Adding behavior without altering the class itself.
    * Want to augment an object with additional functionality.
    * Do not want to rewrite or alter existing code (Open-Closed Principle)
    * Want to keep new functionality separate (Single Responsibility Principle)
    * Need to be able to interact with existing structures.
        * Two options:
            * Inherit from required object if possible; some objects are sealed.
            * Build a Decorator, which simply references the decorated object(s).
* Facilitates the addition of behaviors to individual objects without inheriting from them.
* A decorator keeps the reference to the decorated object(s).
* May or may not proxy over calls.
* Exists in static variation.
    * `X<Y<Foo>>`
    * Very limited due to inability to inherit from type parameters.

## Facade Pattern ##
* Motivation
    * Blaancing complexity and presentation/usability.
    * Typical home example.
        * Many subsystems (electrical, sanitation)
        * Complex internal structure (e.g., floor layers)
        * End user is not exposed to internals.
    * Same with software
        * Many systems working to provide flexibility.
        * API consumers want it to 'just work'.
* Provides a simple, easy to understand/user interface over a large and sophisticated body of code.
* Build a facade to provide a simplified API over a set of classes.
* May wish to (optionally) expose internals through the facade.
* May allow users to 'escalate' to use more complex APIs if they need to.

## Flyweight Pattern ##
* Motivation
    * Avoid redundancy when storing data.
        * E.g., MMORPG
            * Plenty of users with identical first/last names.
            * No sense in storing same first/last name over and over again.
            * Store a list of names and pointers to them.
    * .NET perform string interning, so an identical string is stored only once.
    * E.g., bold or italic text in the console.
        * Don't want each character to have a formatting character.
        * Operate on ranges (e.g., line number, start/end positions)
* A space optimization technique that lets us use less memory by storing externally the data associated with similar objects.
* Store common data externally.
* Define the idea of 'ranges' on homogeneous collections and store data related to those ranges.
* .NET string interning is the 'Flyweight pattern'.


