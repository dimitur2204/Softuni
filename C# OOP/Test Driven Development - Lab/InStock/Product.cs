
using System;

namespace InStock
{
    public class Product
    {
        private string label;
        private decimal price;
        private int quanitity;
        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }
        public string Label
        {
            get => this.label;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Label cannot be null");
                }
                this.label = value;
            }
        }
        public decimal Price
        {
            get => this.price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to zero");
                }
                this.price = value;
            }
        }

        public int Quantity
        {
            get => this.quanitity;
                private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Quantity cannot be less or equal to zero");
                }
                this.quanitity = value;
            }
        }
    }
}
