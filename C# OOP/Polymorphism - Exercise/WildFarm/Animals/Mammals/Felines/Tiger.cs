using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food, int quantity)
        {
            var foodType = food.GetType().Name;
            if (foodType != "Meat")
            {
                Console.WriteLine($"{nameof(Tiger)} does not eat {foodType}!");
            }
            else
            {
                this.Weight += 1 * quantity;
                this.FoodEaten += quantity;
            }
        }

        public override string AskForFood()
        {
            return "ROAR!!!";
        }

        public override string ToString()
        {
            return $"{nameof(Tiger)} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
