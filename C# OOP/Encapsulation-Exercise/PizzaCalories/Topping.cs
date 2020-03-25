using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    class Topping
    {
        private const double defaultCal = 2;
        private const double meatCal = 1.2;
        private const double veggiesCal = 0.8;
        private const double cheeseCal = 1.1;
        private const double sauceCal = 0.9;

        private string type;
        private double weight;
        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;
            private set
            {
                if (ValidateToppingType(value))
                {
                    this.type = value;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
            }
        }
        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value >= 1 && value <= 50)
                {
                    this.weight = value;
                }
                else
                {
                    throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
                }
            }
        }

        public double GetCalories()
        {
            if (this.Type.ToLower() == "meat")
            {
                return defaultCal * this.weight * meatCal;
            }
            else if (this.Type.ToLower() == "cheese")
            {
                return defaultCal * this.weight * cheeseCal;
            }
            else if (this.Type.ToLower() == "veggies")
            {
                return defaultCal * this.weight * veggiesCal;
            }
            else
            {
                return defaultCal * this.weight * sauceCal;
            }
        }
        private bool ValidateToppingType(string type)
        {
            var types = new List<string>
            {
                "meat",
                "cheese",
                "sauce",
                "veggies"
            };
            if (types.Contains(type.ToLower()))
            {
                return true;
            }
            return false;
        }
        //•	Meat – 1.2;
        //•	Veggies – 0.8;
        //•	Cheese – 1.1;
        //•	Sauce – 0.9;

    }
}
