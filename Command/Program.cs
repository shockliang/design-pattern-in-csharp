using System;
using System.Collections.Generic;
using static System.Console;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var ba = new BankAccount();
            var commands = new List<BankAccountCommand>()
            {
                new BankAccountCommand(ba, BankAccountCommand.Action.Deposit, 100),
                new BankAccountCommand(ba, BankAccountCommand.Action.Withdraw, 50),
            };

            WriteLine(ba);

            foreach (var c in commands)
            {
                c.Call();
            }

            WriteLine(ba);
        }
    }
}
