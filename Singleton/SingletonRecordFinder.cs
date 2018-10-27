using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using MoreLinq;
using static System.Console;

namespace Singleton
{
    public class SingletonRecordFinder
    {
        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
                result += SingletonDatabase.Instance.GetPopulation(name);
            return result;
        }
    }
}