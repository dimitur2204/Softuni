namespace SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                var carInfo = Console.ReadLine().Split();
                var currentCar = new Car(carInfo[0],double.Parse(carInfo[1]),double.Parse(carInfo[2]));
                cars.Add(currentCar);
            }
            var command = Console.ReadLine();
            while (command != "End")
            {
                var tokens = command.Split();
                var carModel = tokens[1];
                var distance = double.Parse(tokens[2]);
                try
                {
                    var car = cars.First(c => c.Model == carModel);
                    car.Drive(distance);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                command = Console.ReadLine();
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
