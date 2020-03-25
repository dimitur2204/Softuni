using System;

namespace _1._Gift_Box_Coverage
{
    class Program
    {
        static void Main(string[] args)
        {
            double sizeOfSide = double.Parse(Console.ReadLine());
            int numberOfSheets = int.Parse(Console.ReadLine());
            double areaOfSingleSheet = double.Parse(Console.ReadLine());
            double areaOfBox = sizeOfSide * sizeOfSide * 6;
            double areaOfSheets = 0;
            for (int i = 1; i <= numberOfSheets; i++)
            {
                if (i % 3 == 0)
                {
                    areaOfSheets += areaOfSingleSheet * 0.25;
                }
                else
                {
                    areaOfSheets += areaOfSingleSheet;
                }
            }
            double percantageCovered =  areaOfSheets/areaOfBox  * 100;
            Console.WriteLine($"You can cover {percantageCovered:f2}% of the box.");
        }
    }
}
