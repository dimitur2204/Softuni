using System;
using System.Collections.Generic;
using System.Text;

namespace _08._Vehicle_Catalogue
{
    class Catalog
    {
        public Catalog(List<Car> cars, List<Truck> trucks) 
        {
            Cars = cars;
            Trucks = trucks;
        }
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }
}
