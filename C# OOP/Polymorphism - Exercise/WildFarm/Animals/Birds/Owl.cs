using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            :base(name,weight)
        {
            this.WingSize = wingSize;
        }
        public override double WingSize { get; }

        public override void Eat(Food food, int quantity)
        {
            if (food.GetType().Name != "Meat")
            {
                Console.WriteLine($"{nameof(Owl)} does not eat {typeof(Food)}!");
            }
            else
            {
                this.Weight += 0.25 * quantity;
                this.FoodEaten += quantity;
            }
        }

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }

        public override string ToString()
        {
            return $"{nameof(Owl)} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
