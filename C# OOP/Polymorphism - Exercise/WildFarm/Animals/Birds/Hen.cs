using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        public Hen(string name,double weight,double wingSize)
            :base(name,weight)
        {
            this.WingSize = wingSize;
        }
        public override double WingSize { get; }

        public override void Eat(Food food, int quantity)
        {
            this.Weight += 0.35 * quantity;
            this.FoodEaten+= quantity;
        }

        public override string AskForFood()
        {
            return "Cluck";
        }

        public override string ToString()
        {
            return $"{nameof(Hen)} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
