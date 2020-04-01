using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Birds
{
    public abstract class Bird : Animal
    {
        public Bird(string name, double weight)
            :base(name, weight)
        {

        }
        public abstract double WingSize { get; }
       
    }
}
