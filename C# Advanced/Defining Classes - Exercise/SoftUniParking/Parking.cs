
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private readonly List<Car> cars;
        private readonly int  capacity;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new List<Car>(capacity);
        }

        public int Count => this.cars.Count;
        public string AddCar(Car car)
        {
            if (cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (cars.Count >= capacity)
            {
                return "Parking is full!";
            }
            else
            {
                cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string regNumber)
        {
            if (cars.All(c => c.RegistrationNumber != regNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                cars.Remove(cars.FirstOrDefault(c => c.RegistrationNumber == regNumber));
                return $"Successfully removed {regNumber}";
            }
        }

        public Car GetCar(string regNumber)
        {
            return cars.FirstOrDefault(c => c.RegistrationNumber == regNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var regNumber in RegistrationNumbers)
            {
                cars.Remove(cars.FirstOrDefault(c => c.RegistrationNumber == regNumber));
            }
        }
    }
}
