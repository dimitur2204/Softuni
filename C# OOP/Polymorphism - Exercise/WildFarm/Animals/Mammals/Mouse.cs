using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food, int quantity)
        {
            if (!(food is Vegetable) && !(food is Fruit))
            {
                Console.WriteLine($"{nameof(Mouse)} does not eat {food.GetType().Name}!");
            }
            else
            {
                this.Weight += 0.1 * quantity;
                this.FoodEaten += quantity;
            }
        }

        public override string AskForFood()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return $"{nameof(Mouse)} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
