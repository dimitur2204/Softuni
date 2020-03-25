using System;

namespace Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputCommand = Console.ReadLine();
            double sumOfCoins = 0.0;
            double nutsPrice = 2.0;
            double waterPrice = 0.7;
            double crispsPrice = 1.5;
            double sodaPrice = 0.8;
            double cokePrice = 1.0;

            while (inputCommand != "Start")
            {
                double coinInserted;
                if (double.TryParse(inputCommand, out coinInserted))
                {
                    if (coinInserted == 0.1 || coinInserted == 0.2 || coinInserted == 0.5 || coinInserted == 1 || coinInserted == 2)
                    {
                        sumOfCoins += coinInserted;
                        inputCommand = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine($"Cannot accept {coinInserted}");
                        inputCommand = Console.ReadLine();
                    }
                }
            }
            inputCommand = Console.ReadLine();
            while (inputCommand != "End")
            {
                if (inputCommand == "Nuts" || inputCommand == "Water" || inputCommand == "Crisps" || inputCommand == "Soda" || inputCommand == "Coke")
                {
                    if (inputCommand == "Nuts" && sumOfCoins >= nutsPrice)
                    {
                        sumOfCoins -= nutsPrice;
                        Console.WriteLine("Purchased nuts");
                        inputCommand = Console.ReadLine();
                    }
                    else if (inputCommand == "Water" && sumOfCoins >= waterPrice)
                    {
                        sumOfCoins -= waterPrice;
                        Console.WriteLine("Purchased water");
                        inputCommand = Console.ReadLine();
                    }
                    else if (inputCommand == "Crisps" && sumOfCoins >= crispsPrice)
                    {
                        sumOfCoins -= crispsPrice;
                        Console.WriteLine("Purchased crisps");
                        inputCommand = Console.ReadLine();
                    }
                    else if (inputCommand == "Soda" && sumOfCoins >= sodaPrice)
                    {
                        sumOfCoins -= sodaPrice;
                        Console.WriteLine("Purchased soda");
                        inputCommand = Console.ReadLine();
                    }
                    else if (inputCommand == "Coke" && sumOfCoins >= cokePrice)
                    {
                        sumOfCoins -= cokePrice;
                        Console.WriteLine("Purchased coke");
                        inputCommand = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                        inputCommand = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                    inputCommand = Console.ReadLine();
                }
            }
            Console.WriteLine($"Change: {sumOfCoins:F2}");
        }
    }
}

