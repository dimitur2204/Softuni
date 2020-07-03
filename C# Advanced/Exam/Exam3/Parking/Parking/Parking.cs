
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> cars;
        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            this.cars = new List<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => this.cars.Count;

        public void Add(Car car)
        {
            if (cars.Count != this.Capacity)
            {
                this.cars.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            return cars.Remove(cars.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model));
        }

        public Car GetLatestCar()
        {
            if (cars.Any())
            {
                return cars.OrderByDescending(x => x.Year).ToArray()[0];
            }
            return null;
        }

        public Car GetCar(string manufacturer, string model)
        {
            return cars.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var car in cars)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
