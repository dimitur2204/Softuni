using System;

namespace Christmas_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyWanted = double.Parse(Console.ReadLine());
            double fantasyBooks = double.Parse(Console.ReadLine());
            double horrorBooks = double.Parse(Console.ReadLine());
            double romanceBooks = double.Parse(Console.ReadLine());
            double sumOfMoney = (fantasyBooks * 14.90 + horrorBooks * 9.80 + romanceBooks * 4.30);
            double moneyGainedAfterDDS = sumOfMoney - (sumOfMoney * 0.2);
            if (moneyGainedAfterDDS >= moneyWanted)
            {
                double vuznagrajdenie = Math.Round((moneyGainedAfterDDS - moneyWanted) * 0.1);
                double donatedMoney = moneyGainedAfterDDS - vuznagrajdenie; 
                Console.WriteLine($"{donatedMoney:f2} leva donated.");
                Console.WriteLine($"Sellers will receive {vuznagrajdenie} leva.");
            }
            else
            {
                double moneyNeeded = moneyWanted - moneyGainedAfterDDS;
                Console.WriteLine($"{moneyNeeded:f2} money needed.");
            }
        }
    }
}
