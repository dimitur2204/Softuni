using System;

namespace Christmas_Sweets
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceOfBaklava = double.Parse(Console.ReadLine());
            double priceOfMuffins = double.Parse(Console.ReadLine());
            double kgOfShtolen = double.Parse(Console.ReadLine());
            double kgOfCandies = double.Parse(Console.ReadLine());
            double kgOfCookies = double.Parse(Console.ReadLine());
            double priceOfShtolen = 0.6 * priceOfBaklava + priceOfBaklava;
            double priceOfCandies = 0.8 * priceOfMuffins + priceOfMuffins;
            double priceOfCookies = 7.5 * kgOfCookies;
            double moneyNeeded = (kgOfShtolen * priceOfShtolen + kgOfCandies * priceOfCandies + priceOfCookies);
            Console.WriteLine($"{moneyNeeded:F2}");
        }
    }
}
