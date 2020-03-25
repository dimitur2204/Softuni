using System;

namespace Summer_Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            int budgetForShopping = int.Parse(Console.ReadLine());
            double priceOfHavliq = double.Parse(Console.ReadLine());
            int percentDiscount = int.Parse(Console.ReadLine());
            double priceOfUmbrella = 2.0 / 3 * priceOfHavliq;
            double priceOfFlipFlops = 0.75 * priceOfUmbrella;
            double priceOfBag = 1.0 / 3 * (priceOfFlipFlops + priceOfHavliq);
            double sumNeeded = (priceOfBag + priceOfFlipFlops + priceOfHavliq + priceOfUmbrella) * ((100 - percentDiscount) / 100.0);
            if (budgetForShopping >= (sumNeeded))
            {
                Console.WriteLine($"Annie's sum is {sumNeeded:F2} lv. She has {(budgetForShopping - sumNeeded):f2} lv. left.");
            }
            else
            {
                Console.WriteLine($"Annie's sum is {sumNeeded:f2} lv. She needs {(sumNeeded - budgetForShopping):F2} lv. more.");
            }
        }
    }
}
