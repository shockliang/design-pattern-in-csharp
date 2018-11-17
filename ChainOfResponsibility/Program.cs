using System;
using static System.Console;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            var goblin = new Creature("Goblin", 2, 2);
            WriteLine(goblin);

            var root = new CreatureModifier(goblin);

            root.Add(new NoBonusesModifier(goblin));

            WriteLine("Let's double the goblin's attack");

            root.Add(new DoubleAttackModifier(goblin));

            WriteLine("Let's increase goblin's defense");
            root.Add(new IncreasedDefenseModifier(goblin));

            root.Handle();

            WriteLine(goblin);
        }
    }
}
