using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using MoreLinq;
using static System.Console;

namespace Singleton
{
    public class ConfigurableRecordFinder
    {
        private readonly IDatabase database;

        public ConfigurableRecordFinder(IDatabase database)
        {
            this.database = database ?? throw new ArgumentNullException(nameof(database));
        }

        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
                result += database.GetPopulation(name);
            return result;
        }
    }
}