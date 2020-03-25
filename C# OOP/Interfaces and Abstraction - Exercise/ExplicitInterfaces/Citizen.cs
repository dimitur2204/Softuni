using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    class Citizen : IPerson, IResident
    {
        public Citizen(string name, string country, int age)
        {
            this.name = name;
            this.age = age;
            this.country = country;
        }
        public string name { private get; set; }

        public int age { get; set; }

        public string country { get; set; }

        string IPerson.GetName()
        {
            return this.name;
        }
        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.name}";
        }
    }
}
