using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Products.Beverages
{
    class Beverage : Product
    {
        public Beverage(string name, decimal price, double milliliters)
            :base(name,(decimal)price)
        {
            this.Milliliters = milliliters;
        }
        public virtual double Milliliters { get; set; }
    }
}
