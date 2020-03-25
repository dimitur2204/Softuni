using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    class Child : Person
    {
        private int age;
        public Child(string name, int age)
            : base(name, age)
        {
            this.Age = age;
        }
        public new int Age 
        {
            get => this.age;
            private set 
            {
                if (value > 15)
                {
                    throw new ArgumentException("Children age cannot be more than 15");
                }
                else
                {
                    this.age = value;
                }
            } 
        }
    }
}
