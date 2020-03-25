using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            this.Horsepower = horsePower;
            this.Fuel = fuel;
            DefaultFuelConsumption = 1.25;
        }
        protected double DefaultFuelConsumption { get; set; }
        public virtual double FuelConsumption  { get; set; }       
        public double Fuel { get; set; }
        public int Horsepower { get; set; }
       protected virtual void Drive(double kilometers) 
        {
            this.Fuel -= kilometers * DefaultFuelConsumption;
        }
    }
}
