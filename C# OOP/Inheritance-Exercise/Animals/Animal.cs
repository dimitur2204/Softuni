using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Animal
    {
        private string name;
        private int? age;
        private string gender;
        public Animal(string name, int? age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        public string Name 
        {
            get => this.name;
            private set 
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.name = value;
            } 
        }
        public int? Age 
        {
            get => this.age;
            private set
            {
                    if (value < 0 || value == null)
                    {
                        throw new ArgumentException("Invalid input!");
                    }
                    this.age = value;
            }
        }
        public virtual string Gender 
        {
            get => this.gender; 
            private set 
            {
                if (value.ToLower() != "male" && value.ToLower() != "female")
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.gender = value;
            }
        }
        public virtual string ProduceSound() 
        {
            return "Animal sounds...";
        }
    }
}
