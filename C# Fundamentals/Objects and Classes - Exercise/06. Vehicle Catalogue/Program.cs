using System;
using System.Collections.Generic;
using System.Linq;
namespace _06._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> cars = new List<Vehicle>();
            List<Vehicle> trucks = new List<Vehicle>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputTokens = input.Split();
                string type = inputTokens[0];
                string model = inputTokens[1];
                string color = inputTokens[2];
                int horsepower = int.Parse(inputTokens[3]);
                Vehicle vehicle = new Vehicle(type, model, color, horsepower);
                if (vehicle.Type == "car")
                {
                    cars.Add(vehicle);
                }
                else
                {
                    trucks.Add(vehicle);
                }
                input = Console.ReadLine();
            }
            List<Vehicle> allVehicles = cars.Concat(trucks).ToList();
            string currentModel = Console.ReadLine();
            while (currentModel != "Close the Catalogue")
            {
                List<Vehicle> vehicleOfCurrentModel = allVehicles.Where(x => x.Model == currentModel).ToList();
                vehicleOfCurrentModel.ForEach(x => Console.WriteLine(x.ToString()));
                currentModel = Console.ReadLine();
            }
            double sumOfCars = GetVehicleHorsepowerSum(cars);
            double sumOfTrucks = GetVehicleHorsepowerSum(trucks);
            //Cars have average horsepower of: 413.33.
            //Trucks have average horsepower of: 250.00.
            if (cars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {sumOfCars/cars.Count:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }
            if (trucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {sumOfTrucks/trucks.Count:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }
        static double GetVehicleHorsepowerSum(List<Vehicle> vehicles) 
        {
            List<double> carsHorsepower = new List<double>();
            foreach (var vehicle in vehicles)
            {
                carsHorsepower.Add(vehicle.Horsepower);
            }
            return carsHorsepower.Sum();
        }
    }
}
