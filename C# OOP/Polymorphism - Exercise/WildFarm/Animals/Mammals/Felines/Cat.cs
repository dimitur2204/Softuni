using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food, int quantity)
        {
            var foodType = food.GetType().Name;
            if (foodType != "Vegetable" && foodType != "Meat")
            {
                Console.WriteLine($"{nameof(Cat)} does not eat {foodType}!"); 
            }
            else
            {
                this.Weight += 0.30 * quantity;
                this.FoodEaten += quantity;
            }
        }

        public override string AskForFood()
        {
            return "Meow";
        }

        public override string ToString()
        {
            return $"{nameof(Cat)} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
