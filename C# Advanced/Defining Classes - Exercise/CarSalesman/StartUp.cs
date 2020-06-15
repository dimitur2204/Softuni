
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace CarSalesman
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var engines = new List<Engine>();
            for (int i = 0; i < n; i++)
            {
                var engineInfo = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                var model = engineInfo[0];
                var power = int.Parse(engineInfo[1]);
                var engine = new Engine(model, power);
                if (engineInfo.Length >= 3)
                {
                    if (int.TryParse(engineInfo[2], out int displacement))
                    {
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        engine.Efficiency = engineInfo[2];
                    }
                }

                if (engineInfo.Length > 3)
                {
                    engine.Displacement = int.Parse(engineInfo[2]);
                    engine.Efficiency = engineInfo[3];
                }

                engines.Add(engine);
            }

            var m = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            for (int i = 0; i < m; i++)
            {
                var carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var model = carInfo[0];
                var engine = engines.First(e => e.Model == carInfo[1]);
                var car = new Car(model, engine);
                if (carInfo.Length >= 3)
                {
                    if (int.TryParse(carInfo[2], out int weight))
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = carInfo[2];
                    }
                }

                if (carInfo.Length >= 4)
                {
                    car.Weight = int.Parse(carInfo[2]);
                    car.Color = carInfo[3];
                }
                cars.Add(car);
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
