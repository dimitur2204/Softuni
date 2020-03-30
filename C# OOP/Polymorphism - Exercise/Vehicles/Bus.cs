using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    class Bus : Vehicle
    {
        private const double peopleIncrease = 1.4;
        public Bus(double fuelQuant, double fuelCons, double tankCap)
            :base(fuelQuant,fuelCons,tankCap)
        {
            
        }      


        public override string Drive(double distance)
        {
            var fuelConsump = this.FuelConsumption;
                fuelConsump += peopleIncrease;
            var fuelConsumed = distance * fuelConsump;
            if (fuelConsumed > this.FuelQuantity)
            {
                return $"{nameof(Bus)} needs refueling";
            }
            else
            {
                this.FuelQuantity -= fuelConsumed;
                return $"{nameof(Bus)} travelled {distance} km";
            }
        }
        public string DriveEmpty(double distance)
        {
            var fuelConsump = this.FuelConsumption;
            var fuelConsumed = distance * fuelConsump;
            if (fuelConsumed > this.FuelQuantity)
            {
                return $"{nameof(Bus)} needs refueling";
            }
            else
            {
                this.FuelQuantity -= fuelConsumed;
                return $"{nameof(Bus)} travelled {distance} km";
            }
        }

        public override void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }

            if (fuel + this.FuelQuantity > this.TankCap)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                return;
            }

            this.FuelQuantity += fuel;
        }
    }
}
