using System;
using System.Collections.Generic;
using System.IO;

namespace SOLID
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        // Violating the Single Responsibility Principle
        public void Save(string fileName)
        {
            File.WriteAllText(fileName, ToString());
        }

        // Violating the Single Responsibility Principle
        public static Journal Load(string fileName)
        {

        }
        
        // Violating the Single Responsibility Principle
        public void Load(Uri uri)
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I laughed today!");
            j.AddEntry("I ate a bug!");
            Console.WriteLine(j);
        }
    }
}
