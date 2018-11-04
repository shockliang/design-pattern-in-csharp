using System;
using System.Text;
using static System.Console;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new Dragon();
            d.Weight = 123;
            d.Fly();
            d.Crawl();
        }
    }
}
