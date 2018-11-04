using System;
using static System.Console;

namespace Decorator
{
    public interface IBird
    {
        int Weight { get; set; }
        void Fly();
    }

    public class Bird : IBird
    {
        public int Weight { get; set; }

        public void Fly()
        {
            WriteLine($"Soaring in the sky with weight {Weight}");
        }
    }

    public interface ILizard
    {
        int Weight { get; set; }
        void Crawl();
    }

    public class Lizard : ILizard
    {
        public int Weight { get; set; }

        public void Crawl()
        {
            WriteLine($"Crawling in the dirt with Weight {Weight}");
        }
    }

    public class Dragon : IBird, ILizard
    {
        private Bird bird = new Bird();
        private Lizard lizard = new Lizard();
        private int weight;

        public int Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                bird.Weight = weight;
                lizard.Weight = weight;
            }
        }

        public void Crawl() => lizard.Crawl();

        public void Fly() => bird.Fly();
    }
}