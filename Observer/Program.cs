using System;
using static System.Console;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var market = new Market();
            market.PropertyChanged += (sender, eventArgs) =>
            {
                if (eventArgs.PropertyName == "Volatility")
                {
                    WriteLine($"Volatility property changed!");
                }
            };

            market.Volatility = 0.5f;
        }
    }
}
