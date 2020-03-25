using System;

namespace Tailoring_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTables = int.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double areaOfTables = (length + 2 * 0.30) * (width + 2 * 0.30);
            double areaOfSquares = Math.Pow(length / 2, 2);
            double priceOfTables = numberOfTables * (areaOfTables * 7);
            double priceOfSquares = numberOfTables * (areaOfSquares * 9);
            double finalPriceDollars = priceOfSquares + priceOfTables;
            double finalPriceLeva = finalPriceDollars * 1.85;
            Console.WriteLine($"{finalPriceDollars:f2} USD");
            Console.WriteLine($"{finalPriceLeva:f2} BGN");





        }
    }
}
