using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int personsToElevate = int.Parse(Console.ReadLine());
            int capacityOfElevator = int.Parse(Console.ReadLine());
            int numberOfCourses = 0;
            while (personsToElevate > 0)
            {
                personsToElevate -= capacityOfElevator;
                numberOfCourses++;
            }
            Console.WriteLine(numberOfCourses);
        }
    }
}
