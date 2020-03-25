using System;
using System.Collections.Generic;
using System.Text;

namespace _3._Speed_Racing
{
    class Car
    {
        public string model { get; set; }
        public double fuelAmount { get; set; }
        public double fuelConsumption { get; set; }
        public double travelledDistance { get; set; }
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelConsumption = fuelConsumption;
            this.travelledDistance = 0;            
        }
        public void RunDistance(double distance) 
        {
            double fuelNeeded = distance * this.fuelConsumption;
            if (fuelNeeded > this.fuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.travelledDistance += distance;
                fuelAmount -= fuelNeeded;
            }
        }
        public override string ToString()
        {
            return $"{this.model} {this.fuelAmount:f2} {this.travelledDistance}";
        }
    }
}
