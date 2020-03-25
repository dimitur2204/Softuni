using System;
using System.Linq;

namespace _02._Hello__France
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] delimeters = { '|', '-', '>' };
            string[] itemsAndPrices = Console.ReadLine()
                .Split(delimeters, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] itemsType = GetTypeArray(itemsAndPrices);
            double[] itemsPrice = GetPriceArray(itemsAndPrices);
            double budget = double.Parse(Console.ReadLine());
            string boughtItemsString = "";
            for (int i = 0; i < itemsType.Length; i++)
            {
                if (itemsType[i] == "Clothes")
                {
                    if (itemsPrice[i] > 50.0 || !IsBudgetEnough(budget, itemsPrice[i]))
                    {
                        continue;
                    }
                    else
                    {
                        budget -= itemsPrice[i];
                        boughtItemsString += itemsPrice[i] + " ";
                    }

                }
                else if (itemsType[i] == "Shoes" )
                {
                    if (itemsPrice[i] > 35.0 || !IsBudgetEnough(budget, itemsPrice[i]))
                    {
                        continue;
                    }
                    else
                    {
                        budget -= itemsPrice[i];
                        boughtItemsString += itemsPrice[i] + " ";
                    }

                }
                else if (itemsType[i] == "Accessories")
                {
                    if (itemsPrice[i] > 20.5 || !IsBudgetEnough(budget, itemsPrice[i]))
                    {
                        continue;
                    }
                    else
                    {
                        budget -= itemsPrice[i];
                        boughtItemsString += itemsPrice[i] + " ";
                    }

                }
            }
            double[] boughtItems = boughtItemsString
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            double sumBeforeRaising = boughtItems.Sum();
            for (int i = 0; i < boughtItems.Length; i++)
            {
                boughtItems[i] += boughtItems[i] * 0.4;
            }
            foreach (var item in boughtItems)
            {
                Console.Write($"{item:f2} ");
            }
            Console.WriteLine();
            double profit = boughtItems.Sum() - sumBeforeRaising;
            Console.WriteLine($"Profit: {profit:f2}");
            if (budget + boughtItems.Sum() >= 150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }
        }

        static bool IsBudgetEnough(double budget, double price)   
        {
            if (budget >= price )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static string[] GetTypeArray(string[] array) 
        {
            string newString = "";
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 0)
                {
                    newString += array[i] + " ";
                }
            }
            return newString.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }

        static double[] GetPriceArray(string[] array)
        {
            string newString = "";
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 != 0)
                {
                    newString += array[i] + " ";
                }
            }
            return newString.Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
        }
    }
}
