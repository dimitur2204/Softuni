using System;

namespace _01._Distance_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = int.Parse(Console.ReadLine());
            double lengthOfStep = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double distanceTravelled = 0;
            for (int i = 1; i <= steps; i++)
            {
                if (i % 5 == 0)
                {
                    distanceTravelled += lengthOfStep * 0.7;
                    continue;
                }
                distanceTravelled += lengthOfStep;
            }
            double distancePercentage = (distanceTravelled / distance);
            Console.WriteLine($"You travelled {distancePercentage:f2}% of the distance!");
        }
    }
}
