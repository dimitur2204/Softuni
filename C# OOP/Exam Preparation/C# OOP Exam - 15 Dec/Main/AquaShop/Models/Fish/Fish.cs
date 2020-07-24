
using System;
using AquaShop.Models.Fish.Contracts;

namespace AquaShop.Models.Fish
{
    public  abstract class Fish : IFish
    {
        private decimal _price;
        private int _size;
        private string _species;
        private string _name;

        protected Fish(decimal price, string species, string name)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fish name cannot be null or empty");
                }

                this._name = value;
            }
        }

        public string Species
        {
            get => _species;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fish species cannot be null or empty.");
                }

                this._species = value;
            }
        }

        public int Size
        {
            get => _size;
            protected set { this._size = value; } 
        }

        public decimal Price
        {
            get => _price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fish price cannot be below or equal to 0.");
                }

                this._price = value;
            } 
        }

        public abstract void Eat();
    }
}
