using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IIdentifiable, IBirthable, IBuyer
    {
        private string name;
        private int age;
        private string Id;
        private string birthdate;
        private int food = 0;
        public Citizen(string name, int age, string Id, string birthdate)
        {
            this.name = name;
            this.age = age;
            this.Id = Id;
            this.birthdate = birthdate;
        }

        public string ID => this.Id;

        public string Name => this.name;

        public string Birthdate => this.birthdate;

        public int Age => this.age;

        public int Food => this.food;

        public void BuyFood()
        {
            food += 10;
        }
    }
}
