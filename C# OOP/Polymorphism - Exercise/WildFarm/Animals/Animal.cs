using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }
        public string Name { get;}
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }
        public abstract string AskForFood();
        public abstract void Eat(Food food, int quantity);
        public abstract override string ToString();
    }
}
