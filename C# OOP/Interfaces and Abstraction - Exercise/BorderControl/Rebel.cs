using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    class Rebel : IBuyer
    {
        private readonly string name;
        private readonly int age;
        private int food = 0;
        private readonly string group;
        public Rebel(string name, int age, string group)
        {
            this.name = name;
            this.age = age;
            this.group = group;
        }
        public string Name => this.name;

        public int Age => this.age;

        public int Food => this.food;

        public void BuyFood()
        {
            this.food += 5;
        }
    }
}
