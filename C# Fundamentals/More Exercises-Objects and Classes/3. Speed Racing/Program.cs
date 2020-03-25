using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Speed_Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carProps = Console.ReadLine().Split();
                string carModel = carProps[0];
                double amountOfFuel = double.Parse(carProps[1]);
                double amountOfFuelPerKm = double.Parse(carProps[2]);
                Car currentCar = new Car(carModel, amountOfFuel, amountOfFuelPerKm);
                cars.Add(currentCar);
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] vs = command.Split();
                string carModel = vs[1];
                double distance = double.Parse(vs[2]);
                List<Car> currentCar = cars.Where(x => x.model == carModel).ToList();
                currentCar[0].RunDistance(distance);
                command = Console.ReadLine();
            }
            cars.ForEach(x => Console.WriteLine(x));
        }
    }
}
