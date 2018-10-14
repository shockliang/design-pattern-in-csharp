using System;
using System.Text;
using System.Collections.Generic;
using static System.Console;
using Builder.Exercises;

namespace Builder
{
    public class Person
    {
        // Address
        public string StreetAddress, Postcode, City;

        // employment
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $@"
                {nameof(StreetAddress)}: {StreetAddress}, 
                {nameof(Postcode)}: {Postcode}, 
                {nameof(City)}: {City}, 
                {nameof(CompanyName)}: {CompanyName}, 
                {nameof(Position)}: {Position}, 
                {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    public class PersonBuider   // facade
    {
        // reference! 
        protected Person person = new Person();

        public PersonJobBuilder Works => new PersonJobBuilder(person);
        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);

        public static implicit operator Person(PersonBuider personBuider)
        {
            return personBuider.person;
        }

    }

    public class PersonAddressBuilder : PersonBuider
    {
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }

        public PersonAddressBuilder At(string streetAddress)
        {
            person.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder WithPostcode(string postcode)
        {
            person.Postcode = postcode;
            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }
    }

    public class PersonJobBuilder : PersonBuider
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(int amount)
        {
            person.AnnualIncome = amount;
            return this;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // var pb = new PersonBuider();
            // Person person = pb
            //     .Lives
            //         .At("No.9487 Somewhere road")
            //         .In("Big city")
            //         .WithPostcode("5487")
            //     .Works
            //         .At("Some company")
            //         .AsA("Engineer")
            //         .Earning(87000);
            // WriteLine(person);

            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            WriteLine(cb);
        }
    }
}
