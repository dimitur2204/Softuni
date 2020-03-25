using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    class Engine
    {
        public Engine(int speed, int power )
        {
            this.Power = power;
            this.Speed = speed;
        }
        public int Power { get; set; }
        public int Speed { get; set; }
    }
}
