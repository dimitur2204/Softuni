using System;

namespace Vehicles
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var carInfo = Console.ReadLine().Split();          
            var truckInfo = Console.ReadLine().Split();
            var busInfo = Console.ReadLine().Split();
            var car = new Car(double.Parse(carInfo[1]), 
                double.Parse(carInfo[2]), 
                double.Parse(carInfo[3]));
            var truck = new Truck(double.Parse(truckInfo[1]), 
                double.Parse(truckInfo[2]), 
                double.Parse(truckInfo[3]));
            var bus = new Bus(double.Parse(busInfo[1]), 
                double.Parse(busInfo[2]), 
                double.Parse(busInfo[3]));
            var numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                var tokens = Console.ReadLine().Split();
                if (tokens[0] == "Drive")
                {
                    if (tokens[1] == "Car")
                    {
                        Console.WriteLine(car.Drive(double.Parse(tokens[2]))); 
                    }
                    else if (tokens[1] == "Truck")
                    {
                        Console.WriteLine(truck.Drive(double.Parse(tokens[2])));
                    }
                    else if (tokens[1] == "Bus")
                    {
                        Console.WriteLine(bus.Drive(double.Parse(tokens[2])));
                    }
                }
                else if (tokens[0] == "Refuel")
                {
                    if (tokens[1] == "Car")
                    {
                        car.Refuel(double.Parse(tokens[2]));
                    }
                    else if (tokens[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(tokens[2]));
                    }
                    else
                    {
                        bus.Refuel(double.Parse(tokens[2]));
                    }
                }
                else
                {
                    Console.WriteLine(bus.DriveEmpty(double.Parse(tokens[2])));
                }
            }
            Console.WriteLine($"Car: {Math.Round(car.FuelQuantity, 2, MidpointRounding.AwayFromZero):f2}");
            Console.WriteLine($"Truck: {Math.Round(truck.FuelQuantity, 2, MidpointRounding.AwayFromZero):f2}");
            Console.WriteLine($"Bus: {Math.Round(bus.FuelQuantity, 2, MidpointRounding.AwayFromZero):f2}");
        }
    }
}
