using System;

namespace World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMetres = double.Parse(Console.ReadLine());
            double timeInSecondsForMeter = double.Parse(Console.ReadLine());
            double totalTimeSlowed = (Math.Floor((distanceInMetres / 15)) * 12.5);
            double totalTimeNeeded = totalTimeSlowed + (timeInSecondsForMeter * distanceInMetres);
            if (totalTimeNeeded < recordInSeconds)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTimeNeeded:f2} seconds.");
            }
            else
            {
                double missingSeconds = (totalTimeNeeded - recordInSeconds);
                Console.WriteLine($"No, he failed! He was {missingSeconds:f2} seconds slower.");
            }
        }
    }
}
