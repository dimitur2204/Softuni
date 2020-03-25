using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    class Person
    {
        private string name;
        private int age;
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name not provided");
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public int Age 
        {
            get => this.age; 
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be a negative number");
                }
                else
                {
                    this.age = value;
                }
            } 
        }
        public override string ToString()
        {
            return $"Name: {this.name}, Age: {this.age}";
        }
    }
}
