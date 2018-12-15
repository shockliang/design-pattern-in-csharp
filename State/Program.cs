using System;
using System.Collections.Generic;
using static System.Console;

namespace State
{
    class Program
    {


        static void Main(string[] args)
        {
            var state = State.OffHook;

            while (true)
            {
                WriteLine($"The phone is currently {state}");
                WriteLine("Select a trigger");

                for (int i = 0; i < Phone.Rules[state].Count; i++)
                {
                    var (t, _) = Phone.Rules[state][i];
                    WriteLine($"{i}. {t}");
                }

                int input = int.Parse(Console.ReadLine());
                var (_, s) = Phone.Rules[state][input];
                state = s;
            }
        }
    }
}
