
using System;
using SantaWorkshop.Models.Presents.Contracts;

namespace SantaWorkshop.Models.Presents
{
    public class Present: IPresent
    {
        private string _name;
        private int _energyRequired;
        public Present(string name, int energyRequired)
        {
            Name = name;
            EnergyRequired = energyRequired;
        }
        public string Name
        {
            get => this._name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Dwarf name cannot be null or empty");
                }

                this._name = value;
            }
        }
        public int EnergyRequired
        {
            get => this._energyRequired;
            private set
            {
                if (value < 0)
                {
                    this._energyRequired = 0;
                    return;
                }

                this._energyRequired = value;
            }
        }
        public void GetCrafted()
        {
            this.EnergyRequired -= 10;
        }

        public bool IsDone()
        {
            return _energyRequired == 0;
        }
    }
}
