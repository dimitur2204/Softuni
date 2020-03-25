using System;

namespace Meters_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputMeters = int.Parse(Console.ReadLine());
            decimal outputKilometers = inputMeters / 1000.0m;
            Console.WriteLine($"{outputKilometers:F2}");
        }
    }
}
