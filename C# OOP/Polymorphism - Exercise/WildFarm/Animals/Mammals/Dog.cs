using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food, int quantity)
        {
            var foodType = food.GetType().Name;
            if (foodType != "Meat")
            {
                Console.WriteLine($"{nameof(Dog)} does not eat {foodType}!");
            }
            else
            {
                this.Weight += 0.4 * quantity;
                this.FoodEaten += quantity;
            }
        }

        public override string AskForFood()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return $"{nameof(Dog)} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
