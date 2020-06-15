using System;

namespace SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelPerKm)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKm = fuelPerKm;
            this.TravelledDistance = 0;
        }
        public string Model { get; private set; }
        public double FuelAmount { get; private set; }
        public double FuelConsumptionPerKm { get; private set; }
        public double TravelledDistance { get; private set; }

        public void Drive(double amountOfKm) 
        {
            var fuelNeeded = amountOfKm * this.FuelConsumptionPerKm;
            if (fuelNeeded <= this.FuelAmount)
            {
                this.FuelAmount -= fuelNeeded;
                this.TravelledDistance += amountOfKm;
            }
            else
            {
                throw new InvalidOperationException("Insufficient fuel for the drive");
            }
        }
    }
}
