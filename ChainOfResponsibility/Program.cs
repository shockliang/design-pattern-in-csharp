using System;
using static System.Console;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            var goblin = new Creature(game, "Strong Goblin", 3, 3);
            WriteLine(goblin);

            using (new DoubleAttackModifier(game, goblin))
            {
                WriteLine(goblin);
                using (new IncreasedDefenseModifier(game, goblin))
                {
                    WriteLine(goblin);
                }
            }

            WriteLine(goblin);
        }
    }
}
