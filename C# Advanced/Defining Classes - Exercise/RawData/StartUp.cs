
namespace RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                var carInfo = Console.ReadLine().Split();
                var model = carInfo[0];
                var engineSpeed = int.Parse(carInfo[1]);
                var enginePower = int.Parse(carInfo[2]);
                var cargoWeight = int.Parse(carInfo[3]);
                var cargoType = carInfo[4];
                var tire1Pressure = double.Parse(carInfo[5]);
                var tire1Age = int.Parse(carInfo[6]);
                var tire2Pressure = double.Parse(carInfo[7]);
                var tire2Age = int.Parse(carInfo[8]);
                var tire3Pressure = double.Parse(carInfo[9]);
                var tire3Age = int.Parse(carInfo[10]);
                var tire4Pressure = double.Parse(carInfo[11]);
                var tire4Age = int.Parse(carInfo[12]);
                var engine = new Engine(engineSpeed,enginePower);
                var cargo = new Cargo(cargoWeight,cargoType);
                var tire1 = new Tire(tire1Age,tire1Pressure);
                var tire2 = new Tire(tire2Age,tire2Pressure);
                var tire3 = new Tire(tire3Age,tire3Pressure);
                var tire4 = new Tire(tire4Age,tire4Pressure);
                var tires = new List<Tire>() { tire1,tire2,tire3,tire4};
                var currentCar = new Car(model,engine,cargo,tires);
                cars.Add(currentCar);
            }
            var type = Console.ReadLine();
            if (type == "fragile")
            {
                foreach (var car in cars
                    .Where(c => c.Cargo.Type == "fragile" && 
                    c.Tires.Any(t => t.Pressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else
            {
                foreach (var car in cars.Where(c => c.Cargo.Type == "flamable" &&
                c.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
