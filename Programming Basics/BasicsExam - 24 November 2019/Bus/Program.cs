using System;

namespace Bus
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialPassengers = int.Parse(Console.ReadLine());
            int numberOfStops = int.Parse(Console.ReadLine());
            for (int stopNumber = 1; stopNumber <= numberOfStops; stopNumber++)
            {
                int goingPassengers = int.Parse(Console.ReadLine());
                int comingPassengers = int.Parse(Console.ReadLine());
                if (stopNumber % 2 == 0)
                {
                    initialPassengers = initialPassengers - goingPassengers + comingPassengers - 2;
                }
                else
                {
                    initialPassengers = initialPassengers - goingPassengers + comingPassengers + 2;
                }
            }
            Console.WriteLine($"The final number of passengers is : {initialPassengers}");
        }
    }
}
