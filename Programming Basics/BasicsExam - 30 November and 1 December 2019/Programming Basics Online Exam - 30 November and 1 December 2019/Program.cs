using System;

namespace Agency Profit
{
    class Program
    {
        static void Main(string[] args)
        {
        string nameOfCompany = Console.ReadLine();
        int ticketsAdults = int.Parse(Console.ReadLine());
        int ticketsChildren = int.Parse(Console.ReadLine());
        double netoPriceAdult = double.Parse(Console.ReadLine());
        double taksaPrice = double.Parse(Console.ReadLine());
        double netoPriceChildren = netoPriceAdult - (0.7 * netoPriceAdult);
        double PriceAdult = netoPriceAdult + taksaPrice;
        double priceChildren = netoPriceChildren + taksaPrice;
        double priceOfAll = (PriceAdult * ticketsAdults) + (priceChildren * ticketsChildren);
        Console.WriteLine($"The profit of your agency from {nameOfCompany} tickets is {(priceOfAll * 0.2):f2} lv.");
        }
    }
}
