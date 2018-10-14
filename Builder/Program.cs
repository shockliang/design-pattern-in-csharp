using System;
using System.Text;
using System.Collections.Generic;
using static System.Console;

namespace Builder
{
    public class Person
    {
        public string Name;
        public string Position;

        public override string ToString()
        {
            return $"{nameof(Name)}: {name}, {nameof(Position)}: {Position}";
        }
    }

    public class PersonInfoBuilder
    {
        protected Person person = new Person();
        public PersonInfoBuilder Called(string name)
        {
            person.Name = name;
            return this;
        }
    }

    public class PersonJobBuilder: PersonInfoBuilder
    {
        public PersonJobBuilder WorkAsA(string position)
        {
            person.Position = position;
            return this;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var builder = new PersonJobBuilder();

            // This doesn't work cause the PersonInfoBuilder did not return the PersonJobBuilder.
            // builder
            //     .Called("Shock")
            //     .WorkAsA("Nobody");
        }
    }
}
