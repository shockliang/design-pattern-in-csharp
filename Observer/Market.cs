using System.Collections.Generic;
using System.ComponentModel;

namespace Observer
{
    public class Market
    {
        public BindingList<float> Prices = new BindingList<float>();

        public void AddPrice(float price)
        {
            Prices.Add(price);
        }

    }
}