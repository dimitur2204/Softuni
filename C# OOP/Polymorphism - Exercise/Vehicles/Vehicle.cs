using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuant;
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCap)
        {            
            this.FuelConsumption = fuelConsumption;
            this.TankCap = tankCap;
            this.FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity 
        { get => fuelQuant;
            protected set 
            {
                if (value > TankCap)
                {
                    fuelQuant = 0;
                }
                else
                {
                    fuelQuant = value;
                }
            } 
        }
        public  double FuelConsumption { get; protected set; }
        public double TankCap { get; }

        public abstract string Drive(double distance);
        public abstract void Refuel(double fuel);
    }
}
