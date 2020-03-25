using System;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal change = decimal.Parse(Console.ReadLine());       
            int counterOfCoins = 0;

            while (change > 0)
          {
                while (change - 2.0m >= 0)
                {
                    change -=  2.0m;
                    counterOfCoins++;
                }

                while (change - 1.0m >= 0)
                {
                    change -= 1.0m;
                    counterOfCoins++;
                }

                while (change - 0.5m >= 0)
                {
                    change -= 0.5m;
                    counterOfCoins++;
                }

                while (change - 0.2m >= 0)
                {
                    change -= 0.2m;
                    counterOfCoins++;
                }

                while (change - 0.1m >= 0)
                {
                    change -= 0.1m;
                    counterOfCoins++;
                }

                while (change - 0.05m >= 0)
                {
                    change -= 0.05m;
                    counterOfCoins++;
                }

                while (change - 0.02m >= 0)
                {
                    change -= 0.02m;
                    counterOfCoins++;
                }

                while (change - 0.01m >= 0)
                {
                    change -= 0.01m;
                    counterOfCoins++;
                }
            }
            Console.WriteLine(counterOfCoins);
        }
    }
}
