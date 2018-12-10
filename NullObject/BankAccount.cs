using System;
using System.Dynamic;
using ImpromptuInterface;
using static System.Console;

namespace NullObject
{
    public interface ILog
    {
        void Info(string msg);
        void Warn(string msg);
    }

    public class ConsoleLog : ILog
    {
        public void Info(string msg)
        {
            WriteLine(msg);
        }

        public void Warn(string msg)
        {
            WriteLine($"WARNING!!! {msg}");
        }
    }

    public class NullLog : ILog
    {
        public void Info(string msg)
        {

        }

        public void Warn(string msg)
        {

        }
    }

    public class BankAccount
    {
        private ILog log;
        private int balance;

        public BankAccount(ILog log)
        {
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public void Deposit(int amount)
        {
            balance += amount;
            log.Info($"Deposited {amount}, balance is now {balance}");
        }
    }

    public class Null<TInterface> : DynamicObject
        where TInterface : class
    {
        public static TInterface Instance
            => new Null<TInterface>().ActLike<TInterface>();

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = Activator.CreateInstance(binder.ReturnType);
            return true;
        }
    }
}