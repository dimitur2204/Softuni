using System;

namespace Charity_Campaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDays = int.Parse(Console.ReadLine());
            int numberOfBakers = int.Parse(Console.ReadLine());
            int numberOfCakesPerDay = int.Parse(Console.ReadLine());
            int numberOfWafflesPerDay = int.Parse(Console.ReadLine());
            int numberOfPancakesPerDay = int.Parse(Console.ReadLine());
            double sumOfMoney = numberOfDays * numberOfBakers * ((numberOfCakesPerDay * 45) + (numberOfPancakesPerDay * 3.20) + (numberOfWafflesPerDay * 5.80));
            double sumAfterTax = sumOfMoney - (sumOfMoney / 8);
            Console.WriteLine($"{sumAfterTax:f2}");

        }
    }
}
