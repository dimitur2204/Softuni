
namespace CounterStrike.Models.Guns
{
    using System;
    using CounterStrike.Models.Guns.Contracts;
    public abstract class Gun : IGun    
    {
        private string name;
        private int bulletsCount;
        public Gun(string name, int bulletsCount)
        {
            this.Name = name;
            this.BulletsCount = bulletsCount;
        }
        public string Name 
        {
            get => this.name;
            private set 
            {
                if (String.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentException("Gun cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int BulletsCount 
        {
            get => this.bulletsCount;
            protected set 
            {
                if (value < 0) 
                {
                    throw new ArgumentException("Bullets cannot be below 0.");
                }
                this.bulletsCount = value;
            }
        }

        public abstract int Fire();
    }
}
