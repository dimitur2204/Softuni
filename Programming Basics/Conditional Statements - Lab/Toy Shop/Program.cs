using System;

namespace Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceOfHoliday = double.Parse(Console.ReadLine());
            int quantityOfPuzzles = int.Parse(Console.ReadLine());
            int quantityOfTalkingDolls = int.Parse(Console.ReadLine());
            int quantityOfTeddyBears = int.Parse(Console.ReadLine());
            int quantityOfMinions = int.Parse(Console.ReadLine());
            int quantityOfTrucks = int.Parse(Console.ReadLine());
            double priceOfOfPuzzles = 2.60;
            double priceOfTalkingDolls = 3.00;
            double priceOfTeddyBears = 4.1;
            double priceOfMinions = 8.2;
            double priceOfTrucks = 2;
            int totalQuantity = quantityOfTrucks + quantityOfTeddyBears + quantityOfTalkingDolls + quantityOfPuzzles + quantityOfMinions;
            double moneyEarned = (quantityOfMinions * priceOfMinions) + (quantityOfPuzzles * priceOfOfPuzzles) + (quantityOfTalkingDolls * priceOfTalkingDolls) + (quantityOfTeddyBears * priceOfTeddyBears) + (quantityOfTrucks * priceOfTrucks);
            
            if (totalQuantity >= 50)
            {
                moneyEarned = moneyEarned - (moneyEarned * 0.25) ;
            }
            
            double moneyAfterTax = moneyEarned - (moneyEarned * 0.1);
            
            if (moneyAfterTax >= priceOfHoliday) 
            {
                double moneyLeft = moneyAfterTax - priceOfHoliday;
                Console.WriteLine($"Yes! {moneyLeft:f2} lv left.");
            }
            else
            {
                double moneyNeeded = Math.Abs(moneyAfterTax - priceOfHoliday);
                Console.WriteLine($"Not enough money! {moneyNeeded:f2} lv needed.");
            }
        }
    }
}
