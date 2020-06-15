
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, IEnumerable<Tire> tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Tires = tires.ToList();
            this.Cargo = cargo;
        }
        public List<Tire> Tires { get; private set; }
        public string Model { get; private set; }
        public Engine Engine { get; private set; }
        public Cargo Cargo { get; private set; }
    }
}
