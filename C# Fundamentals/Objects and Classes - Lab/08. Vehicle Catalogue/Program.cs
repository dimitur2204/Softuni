using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Vehicle_Catalogue
{
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Horsepower { get; set; }
    }
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
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Weight { get; set; }
    }
    class Program
    {

        static void Main(string[] args)
        {
            //{type}/{brand}/{model}/{horse power / weight}
            string input = Console.ReadLine();
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();
            while (input != "end")
            {
                string[] inputSeparated = input.Split("/", StringSplitOptions.RemoveEmptyEntries);
                if (inputSeparated[0] == "Car")
                {
                    Car currentCar = new Car();
                    currentCar.Brand = inputSeparated[1];
                    currentCar.Model = inputSeparated[2];
                    currentCar.Horsepower = inputSeparated[3];
                    cars.Add(currentCar);
                }
                else
                {
                    Truck currentTruck = new Truck();
                    currentTruck.Brand = inputSeparated[1];
                    currentTruck.Model = inputSeparated[2];
                    currentTruck.Weight = inputSeparated[3];
                    trucks.Add(currentTruck);
                }
                input = Console.ReadLine();
            }
            Catalog catalogue = new Catalog(cars,trucks);
            if (catalogue.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
            }
            foreach (var car in catalogue.Cars.OrderBy(x => x.Brand))
            {
                
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.Horsepower}hp");
            }

            if (catalogue.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
            }
            foreach (var truck in catalogue.Trucks.OrderBy(x => x.Brand))
            {
                
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }
    }
}
