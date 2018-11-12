using System;
using static System.Console;

namespace Proxy
{

    class Program
    {
        static void Main(string[] args)
        {
            ICar car = new CarProxy(new Driver(22));
            car.Drive();
        }
    }
}
