using System;
using System.Linq;
using System.Collections.Generic;
using static System.Console;

namespace Flyweight
{
    [Serializable]
    public class User
    {
        private string fullName;
        public User(string fullName)
        {
            this.fullName = fullName;
        }
    }

    [Serializable]
    public class User2
    {
        private static List<string> strings = new List<string>();
        private int[] names;
        public User2(string fullName)
        {
            int getOrAdd(string s)
            {
                int idx = strings.IndexOf(s);
                if (idx != -1)
                {
                    return idx;
                }
                else
                {
                    strings.Add(s);
                    return strings.Count - 1;
                }
            }

            names = fullName.Split(' ').Select(getOrAdd).ToArray();
        }

        public string FullName => string.Join(" ", names.Select(i => strings[i]));
    }

    class Program
    {
        static void Main(string[] args)
        {
            var ft = new FormattedText("This is a brave new world");
            ft.Capitalize(10, 15);
            WriteLine(ft);
        }
    }
}
