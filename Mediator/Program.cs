using System;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            var room = new ChatRoom();

            var john = new Person("John");
            var jane = new Person("Jane");

            room.Join(john);
            room.Join(jane);

            john.Say("Hi");
            jane.Say("oh, hey John");

            var simon = new Person("Simon");
            room.Join(simon);
            simon.Say("Hi everyone!");

            jane.PrivateMessage("Simon", "Hey Simon!");
        }
    }
}
