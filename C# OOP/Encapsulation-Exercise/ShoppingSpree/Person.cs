using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }
        public List<Product> Products 
        { 
           get => this.products;
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
        public decimal Money 
        {
            get => this.money;
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public void BuyProduct(Product product) 
        {
            this.products.Add(product);
            this.Money -= product.Cost;
        }
        public bool ValidateName(string name)
        {
            if (String.IsNullOrWhiteSpace(name) || String.IsNullOrEmpty(name))
            {
                return false;
            }
            return true;
        }
        public static void ExtractAndAddPeople(string[] personInfo, List<Person> people)
        {
            foreach (var command in personInfo)
            {
                var info = command
                    .Split("=");
                var person = new Person(info[0], decimal.Parse(info[1]));
                people.Add(person);
            }
        }
        public override string ToString()
        {
                if (this.Products.Count == 0)
                {
                    return $"{this.Name} - Nothing bought";
                }
                else
                {
                    return $"{this.Name} - {String.Join(", ", Product.GetProductNames(this.Products))}";
                }
        }
    }
}
