﻿using System;
using System.Text;
using System.Collections.Generic;
using static System.Console;

namespace Builder
{
    public class Person
    {
        public string Name;
        public string Position;

        public class Builder : PersonJobBuilder<Builder>
        {

        }

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    public abstract class PersonBuilder
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }

    public class PersonInfoBuilder<SELF>
        : PersonBuilder
        where SELF : PersonInfoBuilder<SELF>
    {

        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF) this;
        }
    }

    public class PersonJobBuilder<SELF>
        : PersonInfoBuilder<PersonJobBuilder<SELF>>
        where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorkAsA(string position)
        {
            person.Position = position;
            return (SELF) this;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var me = Person.New
                .Called("Shock")
                .WorkAsA("Engineer")
                .Build();
            WriteLine(me);
        }
    }
}
