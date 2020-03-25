using System;
using System.Collections.Generic;
using System.Text;

namespace StarEnigma
{
    class Planet
    {
        public Planet(string name, int population, int soldiers)
        {
            Name = name;
            Population = population;
            Soldiers = soldiers;
        }
        public string Name { get; set; }
        public int Population { get; set; }
        public int Soldiers { get; set; }
    }
}
