using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using MoreLinq;
using static System.Console;

namespace Singleton
{
    public class OrdinaryDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;

        public OrdinaryDatabase()
        {
            WriteLine("Initializing ordinary database");
            capitals = File.ReadAllLines("capitals.txt")
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1))
                );
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }
}