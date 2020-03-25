using System;

namespace Dance_Hall
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double sideOfWardrobe = double.Parse(Console.ReadLine());
            double areaOfHall = length * width;
            double areaOfBench = areaOfHall / 10;
            double areaOfWardrobe = sideOfWardrobe * sideOfWardrobe;
            double areaFreeInM2 = areaOfHall - (areaOfBench + areaOfWardrobe);
            double numberOfDancers = areaFreeInM2 / 0.704;
            Console.WriteLine(Math.Floor(numberOfDancers));
        }
    }
}
