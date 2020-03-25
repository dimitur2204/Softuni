using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class Car : Vehicle 
    {
        public Car(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
           this.DefaultFuelConsumption = 3;
        }
        protected override void Drive(double kilometers)
        {
            this.Fuel -= kilometers * DefaultFuelConsumption;
        }
    }
}
