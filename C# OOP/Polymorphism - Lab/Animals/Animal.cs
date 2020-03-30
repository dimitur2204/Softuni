using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
   public class Animal
    {
        public Animal(string name, string favFood)
        {
            Name = name;
            FavFood = favFood;
        }

        public string Name { get; }
        public string FavFood { get; }
        public virtual string ExplainSelf()
        {
            return "I am an animal";
        }
    }
}
