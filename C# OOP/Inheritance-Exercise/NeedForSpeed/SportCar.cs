using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class SportCar : Car
    {
        public SportCar(int horsePower, double fuel)
    : base(horsePower, fuel)
        {
            this.DefaultFuelConsumption = 10;
        }
        protected new void Drive(double kilometers)
        {
            this.Fuel -= kilometers * DefaultFuelConsumption;
        }
    }
}
