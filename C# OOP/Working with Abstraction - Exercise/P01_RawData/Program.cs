using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{

    class RawData
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();
            var lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                var commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var model = commands[0];
                var engine = new Engine(int.Parse(commands[1]), int.Parse(commands[2]));
                var cargo = new Cargo(int.Parse(commands[3]), commands[4]);
                var tire1 = new Tire(int.Parse(commands[6]), double.Parse(commands[5]));
                var tire2 = new Tire(int.Parse(commands[8]), double.Parse(commands[7]));
                var tire3 = new Tire(int.Parse(commands[10]), double.Parse(commands[9]));
                var tire4 = new Tire(int.Parse(commands[12]), double.Parse(commands[11]));
                var tires = new List<Tire>
                {
                tire1,
                tire2,
                tire3,
                tire4
                };
                var car = new Car(model, engine, tires, cargo);
                cars.Add(car);
            }
            string cargoToFilter = Console.ReadLine();
            var filteredCars = new List<Car>();
            if (cargoToFilter == "fragile")
            {
                filteredCars = cars
                   .Where(x => x.Cargo.Type == cargoToFilter &&
                   x.Tires
                   .Exists(y => y.Pressure < 1))
                   .ToList();
            }
            else
            {
                 filteredCars = cars
                    .Where(x => (x.Cargo.Type == cargoToFilter) &&
                    (x.Engine.Power > 250))
                    .ToList();
            }

            PrintCars(filteredCars);
        }
        static void PrintCars(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}");
            }
        }
    }

}
