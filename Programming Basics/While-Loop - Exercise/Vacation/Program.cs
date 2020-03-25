using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyNeeded = double.Parse(Console.ReadLine());
            double moneyAvaliable = double.Parse(Console.ReadLine());
            int daysCounter = 0;
            int spendingCounter = 0;

            while(spendingCounter != 5 && moneyAvaliable <= moneyNeeded) 
            {
                string command = Console.ReadLine();
                if (command == "spend")
                {
                    double moneySpent = double.Parse(Console.ReadLine());
                    spendingCounter++;
                    if (moneySpent > moneyAvaliable)
                    {
                        moneyAvaliable = 0;
                    }
                    else
                    {
                        moneyAvaliable -= moneySpent;
                    }
                    
                }
                else if (command == "save")
                {
                    double moneySaved = double.Parse(Console.ReadLine());
                    moneyAvaliable += moneySaved;
                }
                daysCounter++;
            }
            if (spendingCounter == 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(daysCounter);
            }
            else
            {
                Console.WriteLine($"You saved the money for {daysCounter} days.");
            }
        }
    }
}
