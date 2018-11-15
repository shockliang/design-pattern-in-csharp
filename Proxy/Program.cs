using System;
using static System.Console;

namespace Proxy
{

    class Program
    {
        static void Main(string[] args)
        {
            var ba = Log<BankAccount>.As<IBankAccount>();
            ba.Deposit(100);
            ba.Withdraw(50);

            WriteLine(ba);
        }
    }
}
