using System;

namespace Alchohol_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceOfWhisky = double.Parse(Console.ReadLine());
            double quantityOfBeer = double.Parse(Console.ReadLine());
            double quantityOfWine = double.Parse(Console.ReadLine());
            double quantityOfRakiq = double.Parse(Console.ReadLine());
            double quantityOfWhisky = double.Parse(Console.ReadLine());
            double priceOfRakiq = priceOfWhisky / 2;
            double priceOfWine = priceOfRakiq - (priceOfRakiq * 0.4);
            double priceOfBeer = priceOfRakiq - (priceOfRakiq * 0.8);
            double sumOfAll = (quantityOfBeer * priceOfBeer) + (quantityOfRakiq * priceOfRakiq) + (quantityOfWhisky * priceOfWhisky) + (quantityOfWine * priceOfWine);
            Console.WriteLine($"{sumOfAll:f2}");
        }
    }
}
