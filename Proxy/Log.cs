using System.Collections.Generic;
using System.Dynamic;
using ImpromptuInterface;
using Dynamitey;
using static System.Console;
using System;
using System.Text;

namespace Proxy
{
    public class Log<T> : DynamicObject
        where T : class, new()
    {
        private readonly T subject;
        private Dictionary<string, int> methodCallCount
            = new Dictionary<string, int>();

        public Log(T subject)
        {
            this.subject = subject;
        }

        // factory method
        public static I As<I>(T subject) where I : class
        {
            if (!typeof(I).IsInterface)
                throw new ArgumentException("I must be an interface type");

            return new Log<T>(subject).ActLike<I>();
        }

        public static I As<I>() where I : class
        {
            if (!typeof(I).IsInterface)
                throw new ArgumentException("I must be an interface type");

            // duck typing here!
            return new Log<T>(new T()).ActLike<I>();
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            try
            {
                WriteLine($"Invoking {subject.GetType().Name}.{binder.Name} with arguments [{string.Join(';', args)}]");
                if (methodCallCount.ContainsKey(binder.Name)) methodCallCount[binder.Name]++;
                else methodCallCount.Add(binder.Name, 1);

                result = subject.GetType().GetMethod(binder.Name).Invoke(subject, args);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        public string Info
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var kvp in methodCallCount)
                {
                    sb.AppendLine($"{kvp.Key} called {kvp.Value} time(s)");
                }

                return sb.ToString();
            }
        }

        public override string ToString()
        {
            return $"{Info}\n{subject}";
        }
    }
}