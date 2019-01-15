using System;
using static System.Console;

namespace MaybeExtension
{
    public static class Maybe
    {
        public static TResult With<TInput, TResult>(this TInput o, Func<TInput, TResult> evaluator)
            where TResult : class
            where TInput : class
        {
            if (o == null)
                return null;
            else
                return evaluator(o);
        }
    }
    public class MaybeMonadDeemo
    {
        public void MyMethod(Person p)
        {
            string postcode;
            if (p != null)
            {
                if (HasMedicalRecord(p) && p.Address != null)
                {
                    CheckAddress(p.Address);
                    if (p.Address.PostCode != null)
                        postcode = p.Address.PostCode.ToString();
                    else
                        postcode = "UNKNOW";
                }
            }
        }

        private void CheckAddress(Address address)
        {
            throw new NotImplementedException();
        }

        private bool HasMedicalRecord(Person p)
        {
            throw new NotImplementedException();
        }
    }

    public class Person
    {
        public Address Address { get; set; }
    }

    public class Address
    {
        public string PostCode { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
