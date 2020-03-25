using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    class Product
    {
        private string name;
        private decimal cost;
        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
        public decimal Cost 
        {
            get => this.cost;
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.cost = value;
            }

        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (ValidateName(value))
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Name cannot be empty");
                }
            }
        }
        public bool ValidateName(string name) 
        {
            if (String.IsNullOrWhiteSpace(name) || String.IsNullOrEmpty(name))
            {
                return false;
            }
            return true;
        }
        public static void ExtractAndAddProducts(string[] productInfo, List<Product> products)
        {
            foreach (var command in productInfo)
            {
                var info = command
                    .Split("=");
                var product = new Product(info[0], decimal.Parse(info[1]));
                products.Add(product);
            }
        }
        public static List<string> GetProductNames(List<Product> products) 
        {
            List<string> names = new List<string>();
            foreach (var product in products)
            {
                names.Add(product.Name);
            }
            return names;
        }
    }
}
