using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings = new List<Topping>();

        public Pizza(string name)
        {
            this.Name = name;
            this.Toppings = new List<Topping>();
        }

        public string Name 
        {
            get => this.name;
             set 
            {
                if (value.Length < 1 || value.Length > 15 || String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public Dough Dough { get => this.dough; set { this.dough = value; } }
        public IReadOnlyList<Topping> Toppings 
        {
            get => this.toppings; 
             set 
            {
                if (value.Count > 10)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }
                else
                {
                    this.toppings = (List<Topping>)value;
                }
            }
        }
        public double GetCalories() 
        {
            double sumOfCalories = 0;
            sumOfCalories += this.dough.GetCalories();
            foreach (var topping in this.toppings)
            {
                sumOfCalories += topping.GetCalories();
            }
            return sumOfCalories;
        }
    }
}
