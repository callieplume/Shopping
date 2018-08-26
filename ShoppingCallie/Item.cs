using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCallie
{
    class Item
    {
        public string name { get; private set; }
        public double price { get; private set; }

        public Item(string name, double price)
        {
            this.name = name;
            this.price = price;
        } 
    }
}
