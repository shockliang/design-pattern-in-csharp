using System;
using System.ComponentModel;
using static System.Console;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var market = new Market();
            market.Prices.ListChanged += (sender, eventArgs) =>
            {
                if (eventArgs.ListChangedType == ListChangedType.ItemAdded)
                {
                    var price = ((BindingList<float>)sender)[eventArgs.NewIndex];
                    WriteLine($"Binding list got a price of {price}");
                }
            };

            market.AddPrice(123.0f);
        }
    }
}
