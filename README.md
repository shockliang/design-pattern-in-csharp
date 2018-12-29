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

## Proxy Pattern ##
* Motivation
    * You are calling `foo.Bar()`.
    * This assumes that foo is in the same process as Bar().
    * What if, Later on, you want to pull all Foo-related operations into a separate process.
    * Proxy to the rescure!
        * Same interface, entirely different behavior.
    * This is called a communication proxy.
        * Other types: loggin, virtual, guarding,...
* A class that functions as an interface to a particular resource. That resource may be remote, expensive to construct, or may require logging or some other added functionality.
* Proxy vs. Decorator
    * Proxy provides an identical interface; decorator provides an enhanced interface.
    * Decorator typically aggregates (or has reference to) what it is decorating; proxy doesn't have to.
    * Proxy might not even be working with a materialized object.
* A proxy has the same interface as the underlying object.
* To create a proxy, simply replicate the existing interface of an object.
* Add relevant functionality to the redefined member functions.
* Different proxyies (communiction, logging, caching, etc.) have completely different behaviors.

## Chain Of Responsibility ##
* Motivation
    * Unethical behavior by an employee; who takes the blame?
        * Employee
        * Manager
        * CEO
    * You click a graphical element on a form
        * Button handles it, stops further processing.
        * Underlying group box.
        * Underlying window.
    * CCG (Collectible Card Game) computer game.
        * Creature has attack and defense values.
        * Those can be boosted by other cards.
* A chain of components who all get a chance to process a command or a query, optionally having default processing implementation and an ability to terminate the processing chain.
* Command Query Separation
    * Command = asking for an action or change (e.g., please set your attack value to 2).
    * Query = asking for information (e.g., please give me your attack value).
    * CQS = having separate means of sending commands and queries to.
        * e.g., direct field access.
* Chain of Reponsibility can be implemented as a chain of references or a centralized construct.
* Enlist objects in the chain, possibly controlling their order.
* Object removal from chain (e.g., in `Dispose()`)

## Command Pattern ##
* Motivation
    * Ordinary c# statements are perishable.
        * Cannot undo a field/property assignment.
        * Cannot directly serialize a sequence of actons(call)
    * Want an object that represents an operation.
        * X should change its propert Y to Z.
        * X should do W().
    * Uses: GUI commands, multi-level undo/redo, macro recording and more!.
* An object which represents an instruction to perform a particular action. Contains all the information necessary for the action to be taken.
* Encapsulate all detail of an operation in a separate object.
* Define instruction for applying the command (either in the command itself, or elsewhere)
* Optionally define instructions for undoing the command.
* Can create composite commands (aka macros)

## Interpreter Pattern ##
* Motivation
    * Textual input needs to be processed.
        * E.g., turned into OOP structures.
    * Some examples
        * Programming language compilers, interpreters and IDEs.
        * HTML, XML ans similar.
        * Numberic expressions (3+4/5)
        * Regular expressions.
    * Turning strings into OOP based structures in a complicated process.
* A component that processes structured text data. Does so by turning it into separate lexical tokens(lexing) and then interpreting sequences of said tokens(parsing).
* Barring simple cases, an interpreter acts in two stages.
* Lexing turns text into a set of tokens
    * e.g., `3*(4+5)` => Lit[3] start Lparen Lit[4] Plus Lit[5] Rparen.
* Parsing tokens into meaningful constructs.
    * e.g., MultiplicationExpression[
        Integer[3],
        AdditionExpression[
            Integer[4], Integer[5]
        ]
    ]
* Parsed data can then be traversed.

## Iterator Pattern ##
* Motivation
    * Iteration (traversal) is a core functionality of various data structures.
    * An iterator is a class that facilitates the traversal.
        * Keeps a reference to the current element.
        * Knows how to move to a diferent element.
    * Iterator is an implicit construct.
        * .Net builds a state machine around your `yield return` statements.
* An object (or, in .Net method) that facilitates the traversal of a data structure.
* An iterator specified how you can traverse an object.
* An iterator object, unlike a method, cannot be recursive.
* Generally, an `IEnumerable<T>` returnning method is enough.
* Iteration works through dock typing - you need a `GetEnumerator()` that yeild return a type that has `Current` and `MoveNext()`.

## Mediator Pattern ##
* Motivation
    * Components may go in and out of a system any time.
        * Chat room
        * MMORPG
    * It make no sense for them to have direct references to one another.
        * Those references may go dead.
    * Solution: Have then all refer some central component that facilites communication.
* A component that facilites communication between other components without them necessarily being aware of each other or having direct(reference) access each other.
* Create the mediator and have each object in the system refer to it.
    * E.g., in a field
* Mediator engages in bidirectional communication with its connected components.
* Mediator has functions the components can call.
* Components have functions the mediator can call.
* Event processing (e.g., RX) libraries make communication easier to implement.

## Memento Pattern ##
* Motivation
    * An object or system goes through changes.
        * e.g., a bank account gets depositsand withdrawals.
    * There are different ways of navigating those changes.
    * One way is to record every change (Command) and teach a command to 'undo' itself.
    * Another is to simply save snapshots of the system.
* A token/handle representing the system state. Let us rool back to the state when the token was generated. May or many not directly expose state information.
* Mementos are used to roll back states arbitrarily.
* A memento is simply a token/handle class with (typically) no functions of its own.
* A memento is not required to expose directly the state(s) to which it reverts the system.
* Can be used to implement undo/redo.

## Null Object Pattern ##
* Motivation
    * When component A uses component B, it typically assumes that B is non-null.
        * You inject B, not B? or some `Option<B>`.
        * You do not check for null(?.) on every call.
    * There is no option of telling A not to use an instance of B.
        * It use is hard-coded.
    * Thus, we build a no-op, non-functioning inheritor of B and pass it into A.
* A no-op object that conforms to the required interface, satisfying a dependency requirement of some other object.
* Implement the required interface.
* Rewrite the methods with empty bodies.
    * If method is non-void, return `default(T)`.
    * If these values are ever used, you are in trouble.
* Supply an instance of Null Object in place of actual object.
* Dynamic construction possible
    * With associated performance implications.

## Observer Pattern ##
* Motivation
    * We need to be informed when certain things happen.
        * Object's property changes.
        * Object does something.
        * Some external event occurs.
    * We want to listen to events and notified when they occur.
    * Built into C# with the event keyword.
        * But then what is this `IObservable<T>/IObserver<T>` for?
        * Waht about `INotifyPropertyChanging/Changed`?
        * And what are `BindingList<T>/ObservableCollection<T>` ?
* An observer is an object that wishes to be informed about events happening in the system. The entity generating the events is an observable.
* Observer is an intrusive approach: an observable must provide an event to subscrible to.
* Special care must be taken to prvent issues in multithreaded scenarios.
* .Net comes with observable collections.
* IObserver<T>/IObservable<T> are used in stream processing (Reactive Extesions).

## State Pattern ##
* Motivation
    * Consider an ordinary telephone.
    * What you do with it depends on the state of the phone/line.
        * If it's ringing or you want to make a call, you can pick it up.
        * Phone must be off the hook to talk/make a call.
        * If you try calling someone, and it's busy, you put the handset down.
    * Changes in state can be explicit or in response to event (Observer pattern).
* A pattern in which the object's behavior is determined by its state. An object transitions from one state to another (something needs to trigger a transition).
* A formalized construct which manage state and transitions is call a `state machine`.
* Given sufficient complexity, it pays to formally define possible states and events/triggers
* Can define.
    * State entry/exit behaviors.
    * Action when a particular event causes a transition.
    * Guard conditions enabling/disabling a transition.
    * Defaut action when no transitions are found for an event.

## Strategy Pattern ##
* Motivation
    * Many algorithms can be decomposed into higher-and lower-level parts.
    * Making tea can be decomposed into:
        * The process of making a hot beverage (boil water, pour into cup);
        * Tea-specific things (put teabag into water)
    * The high-level algorithm can then be reused for making coffee or hot chocolate.
        * Supported by beverage-specific strategies.
* Enables the exact behavior of a system to be selected either at run-time (dynamic) or compile-time (static).
* Also known as policy (esp. in the C++ world)
* Define an algorithm at a high level.
* Define the interface you expect each strategy to follow.
* Provide for either dynamic ofr static compsition of strategy in the overall algorithm.

## Template Method Pattern ##
* Motivation
    * Algorithms can be decomposed into common parts + specifics.
    * Strategy pattern does this through composition
        * High-level algorithm uses an interface.
        * Concrete implementations implement the interface.
    * Template Method does the same thing through inheritance.
        * Overall algorithm makes use of abstract member.
        * Inheritors override the abstract members.
        * Parent template method invoked.
* Allows us to define the 'skeleton' of the algorithm, with concrete implementations defined in subclasses.
* Define an algorithm at a high level.
* Define constituent parts as abstract methods/properties.
* Inherit the algorithm class, providing necessary override.

## Vistor ##
* Motivation
    * Need to define a new operation on an entire class hierarchy.
        * E.g., make a document model printable to HTML/Markdown.
    * Do not want to keep modifying every class in the hierarchy.
    * Need access to non-common aspects of classes in the hierarchy.
        * I.e., an extension method won't do.
    * Create an external component to handle rendering.
        * But avoid type checks.
    * A pattern where a component (visitor) is allowed to traverse the entire inheritance hierarchy. Implemented by propagation a single `visit()` mehtod throughout the entire hierarchy.
    * Dispatch
        * Which function to call?
        * Single dispatch: depends on name of request and type of receiver.
        * Double dispatch: depends on name of request and type of two receivers (type of visitor, type of element being visited)
* Propagate an accept (Visitor v) method throughout the entire hierarchy.
* Create a visitor with `Visit(Fool), Visit(Bar)`, ...for each element in the hierarchy.
* Each `accept()` simply calls visitor. `Visit(this)`.
* Using dynamic, we can invoke right overload based on argument type alone (dynamic dispatch).