using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using MoreLinq;
using static System.Console;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = SingletonDatabase.Instance;
            var city = "Tokyo";
            WriteLine($"{city} has population {db.GetPopulation(city)}");
        }
    }
}
