using System;

namespace Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int ageOfLilly = int.Parse(Console.ReadLine());
            double priceOfWashingMachine = double.Parse(Console.ReadLine());
            int priceOfToys = int.Parse(Console.ReadLine());
            int counterOfToys = 0;
            double sumOfMoney = 0.0;
            int currentFlow = 10;

            for (int i = 1; i <= ageOfLilly; i++)
            {
                if (i % 2 == 0)
                {
                    sumOfMoney += currentFlow - 1;
                    currentFlow += 10;
                }
                else
                {
                    counterOfToys++;
                }
            }

            int sumFromToys = counterOfToys * priceOfToys;
            double sumAfterToys = sumOfMoney + sumFromToys;

            if (sumAfterToys >= priceOfWashingMachine)
            {
                Console.WriteLine($"Yes! {sumAfterToys - priceOfWashingMachine:f2}");
            }
            else
            {
                Console.WriteLine($"No! {priceOfWashingMachine - sumAfterToys:f2}");
            }
        }
    }
}
