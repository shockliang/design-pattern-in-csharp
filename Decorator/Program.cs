using System;
using System.Text;
using static System.Console;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStringBuilder say = "hello ";
            say += "world!";
            WriteLine(say);
        }
    }
}
