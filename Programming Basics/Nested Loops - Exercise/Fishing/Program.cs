using System;

namespace Fishing
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfFishes = int.Parse(Console.ReadLine());
            double profit = 0;
            int fishNumber = 0;
            string fishName = Console.ReadLine(); 
            while (fishName != "Stop" && numberOfFishes != 0)
            {      
                fishNumber++;        
                double fishWeight = double.Parse(Console.ReadLine());
                double sumOfChars = 0;               
                for (int j = 0; j < fishName.Length; j++)
                {
                    sumOfChars += fishName[j];
                }
                double priceOfFish = sumOfChars / fishWeight;
                if (fishNumber % 3 == 0)
                {
                    profit += priceOfFish;
                }
                else
                {
                    profit -= priceOfFish;
                }
                numberOfFishes--;
                if (numberOfFishes == 0)
                {
                    Console.WriteLine("Lyubo fulfilled the quota!");
                    break;
                }
                fishName = Console.ReadLine();               
            }           
            if (profit > 0)
            {
                Console.WriteLine($"Lyubo's profit from {fishNumber} fishes is {profit:F2} leva.");
            }
            else
            {
                Console.WriteLine($"Lyubo lost {Math.Abs(profit):F2} leva today.");
            }
        }
    }
}
