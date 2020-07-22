using System;
using System.Collections.Generic;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;

namespace SantaWorkshop.Models.Dwarfs
{
    public abstract class Dwarf : IDwarf
    {
        private string _name;
        private  int _energy;
        private ICollection<IInstrument> instruments;
        protected Dwarf(string name, int energy)
        {
            Name = name;
            Energy = energy;
            this.instruments = new List<IInstrument>();
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

        public int Energy
        {
            get => this._energy;
            protected set
            {
                if (value < 0)
                {
                    this._energy = 0;
                    return;
                }
                this._energy = value;
            }
        }
        public ICollection<IInstrument> Instruments
        {
            get => this.instruments;
        }
        public virtual void Work()
        {
            this.Energy -= 10;
        }

        public virtual void AddInstrument(IInstrument instrument)
        {
            this.Instruments.Add(instrument);
        }
    }
}
