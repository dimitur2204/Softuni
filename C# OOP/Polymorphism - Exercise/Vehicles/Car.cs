using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double ACIncrease = 0.9;
        public Car(double fuelQuant, double fuelConsump, double tankCap)
            :base(fuelQuant,fuelConsump + ACIncrease, tankCap)
        {
            
        }
        public override string Drive(double distance)
        {
            var fuelConsumed = distance * this.FuelConsumption;
            if (fuelConsumed > this.FuelQuantity)
            {
                return $"{nameof(Car)} needs refueling";
            }
            else
            {
                this.FuelQuantity -= fuelConsumed;
                return $"{nameof(Car)} travelled {distance} km";
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
