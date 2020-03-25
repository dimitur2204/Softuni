using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Orders
{
    class Product
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product(int quantity, double price)
        {
            this.Quantity = quantity;
            this.Price = price;
        }
    }
}
