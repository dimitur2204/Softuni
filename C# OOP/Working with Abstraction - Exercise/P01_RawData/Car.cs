using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    class Car
    {
        public Car(string model, Engine engine, List<Tire> tires, Cargo cargo)
        {
            this.Model = model;
            this.Engine = engine;
            this.Tires = tires;
            this.Cargo = cargo;
        }
        public string Model;
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public List<Tire> Tires { get; set; }
    }
}
