using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel)
: base(horsePower, fuel)
        {
            this.DefaultFuelConsumption = 8;
        }
        protected new void Drive(double kilometers)
        {
            this.Fuel -= kilometers * DefaultFuelConsumption;
        }
    }
}
