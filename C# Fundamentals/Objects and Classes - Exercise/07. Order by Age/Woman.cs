using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Order_by_Age
{
    class Woman
    {
        public Woman(string name, string id, int age)
        {
            this.Name = name;
            this.ID = id;       
            this.Age = age;
        }
        public string ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"{this.Name} with ID: {this.ID} is {this.Age} years old.";
        }
    }
}
