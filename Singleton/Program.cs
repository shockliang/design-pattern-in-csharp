using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using MoreLinq;
using static System.Console;

namespace Singleton
{
    public class CEO
    {
        private static string name;
        private static int age;

        public string Name
        {
            get => name;
            set => name = value;
        }
        public int Age
        {
            get => age;
            set => age = value;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {name}, {nameof(Age)}: {Age}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var ceo = new CEO();
            ceo.Name = "Adam Smith";
            ceo.Age = 55;

            var ceo2 = new CEO();
            WriteLine(ceo2);
        }
    }
}
