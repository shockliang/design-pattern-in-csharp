using System;

namespace Decorator.Coding.Exercise
{
    public class Bird
    {
        public int Age { get; set; }

        public string Fly()
        {
            return (Age < 10) ? "flying" : "too old";
        }
    }

    public class Lizard
    {
        public int Age { get; set; }

        public string Crawl()
        {
            return (Age > 1) ? "crawling" : "too young";
        }
    }

    public class Dragon // no need for interfaces
    {
        private int age;
        private Bird flyAbility;
        private Lizard crawlAbility;
        public Dragon()
        {
            flyAbility = new Bird();
            crawlAbility = new Lizard();
        }

        public int Age
        {
            get { return age; }
            set 
            {
                age = value;
                flyAbility.Age = value;
                crawlAbility.Age = value;
            }
        }

        public string Fly() => flyAbility.Fly();

        public string Crawl() => crawlAbility.Crawl();
    }
}
