using System;

namespace Proxy.Coding.Exercise
{
    public class Person
    {
        public int Age { get; set; }

        public string Drink()
        {
            return "drinking";
        }

        public string Drive()
        {
            return "driving";
        }

        public string DrinkAndDrive()
        {
            return "driving while drunk";
        }
    }

    public class ResponsiblePerson
    {
        private Person person;
        public ResponsiblePerson(Person person)
        {
            this.person = person;
        }

        public int Age
        {
            get { return person.Age; }
            set { person.Age = value; }
        }

        public string Drink()
            => person.Age > 18 ? person.Drink() : "too young";

        public string Drive()
            => person.Age > 16 ? person.Drive() : "too young";

        public string DrinkAndDrive() => "dead";
    }
}
