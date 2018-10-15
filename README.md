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
