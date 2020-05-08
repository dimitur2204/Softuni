﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    class Truck : Vehicle
    {
        private const double ACIncrease = 1.6;
        public Truck(double fuelQuant, double fuelConsump,double tankCap)
            :base(fuelQuant, fuelConsump + ACIncrease, tankCap)
        {

        }   

        public override string Drive(double distance)
        {
            var fuelConsumed = distance * this.FuelConsumption;
            if (fuelConsumed > this.FuelQuantity)
            {
                return $"{nameof(Truck)} needs refueling";
            }
            else
            {
                this.FuelQuantity -= fuelConsumed;
                return $"{nameof(Truck)} travelled {distance} km";
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
            //Loss due to hole in the tank
            fuel = fuel * 95 / 100;
            this.FuelQuantity += fuel;
        }
    }
}