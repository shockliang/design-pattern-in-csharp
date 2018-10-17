using System;
using System.Linq;
using System.Collections.Generic;
using static System.Console;

namespace Factories
{
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            WriteLine("Drinking hot tea");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            WriteLine("I LOVE HOT COFFEE!");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"Put in a tea bag, boil water, pour {amount} ml, add lemon, enjoy!");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"Grind some beans, boil water, pour {amount} ml, enjoy!");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        // public enum AvailableDrink
        // {
        //     Coffee, Tea
        // }

        // private Dictionary<AvailableDrink, IHotDrinkFactory> factories =
        //     new Dictionary<AvailableDrink, IHotDrinkFactory>();
        // public HotDrinkMachine()
        // {
        //     foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
        //     {
        //         var factory = (IHotDrinkFactory)Activator.CreateInstance(
        //             Type.GetType($"Factories.{Enum.GetName(typeof(AvailableDrink), drink)}Factory"));
        //         factories.Add(drink, factory);
        //     }
        // }

        // public IHotDrink MakeDrink(AvailableDrink drink, int amount)
        // {
        //     return factories[drink].Prepare(amount);
        // }

        private List<Tuple<string, IHotDrinkFactory>> factories =
            new List<Tuple<string, IHotDrinkFactory>>();

        public HotDrinkMachine()
        {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    factories.Add(Tuple.Create(
                        t.Name.Replace("Factory", string.Empty),
                        (IHotDrinkFactory)Activator.CreateInstance(t)
                    ));
                }
            }
        }

        public IHotDrink MarkDrink()
        {
            WriteLine($"Available drinks:");
            for (int i = 0; i < factories.Count; i++)
            {
                var tuple = factories[i];
                WriteLine($"{i}: {tuple.Item1}");
            }

            while (true)
            {
                string s;
                if ((s = Console.ReadLine()) != null
                    && int.TryParse(s, out int i)
                    && i >= 0
                    && i < factories.Count)
                {
                    WriteLine($"Specify amount: ");
                    s = ReadLine();
                    if (s != null
                        && int.TryParse(s, out int amount)
                        && amount > 0)
                    {
                        return factories[i].Item2.Prepare(amount);
                    }
                }

                WriteLine("Incorrect input, try again!");
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var machine = new HotDrinkMachine();
            var drink = machine.MarkDrink();
            drink.Consume();
        }
    }
}
