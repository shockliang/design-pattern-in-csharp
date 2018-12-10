using System;
using Autofac;
using static System.Console;

namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = Null<ILog>.Instance;
            log.Info("something would not happen");
            var ba = new BankAccount(log);
            ba.Deposit(100);
        }
    }
}
