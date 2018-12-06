using System;
using static System.Console;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            var ba = new BankAccount(100);
            var m1 = ba.Deposit(50);    // 150
            var m2 = ba.Deposit(25);    // 175
            WriteLine(ba);

            ba.Restore(m1);
            WriteLine(ba);

            ba.Restore(m2);
            WriteLine(ba);

        }
    }
}
