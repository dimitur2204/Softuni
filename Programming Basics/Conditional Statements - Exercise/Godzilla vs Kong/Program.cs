using System;

namespace Godzilla_vs_Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budgetForFilming = double.Parse(Console.ReadLine());
            int quantityOfExtras = int.Parse(Console.ReadLine());
            double priceOfClothesPerExtra = double.Parse(Console.ReadLine());
            double priceOfClothes = priceOfClothesPerExtra * quantityOfExtras;
            double priceOfDecor = budgetForFilming * 0.1;
            if (quantityOfExtras >= 150)
            {
                priceOfClothes = priceOfClothes - (priceOfClothes * 0.1);
            }

            double totalPrice = priceOfClothes + priceOfDecor;
            if (totalPrice > budgetForFilming)
            {
                double moneyNeeded = totalPrice - budgetForFilming;
                Console.WriteLine($"Not enough money!");
                Console.WriteLine($"Wingard needs {moneyNeeded:f2} leva more.");
            }
            else
            {
                double moneyLeft = budgetForFilming - totalPrice;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {moneyLeft:f2} leva left.");
            }
        }
    }
}
