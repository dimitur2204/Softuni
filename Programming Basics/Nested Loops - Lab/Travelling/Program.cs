using System;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destinationCommand = Console.ReadLine();
            while (destinationCommand != "End")
            {
                double moneyNeeded = double.Parse(Console.ReadLine());
                while (moneyNeeded > 0)
                {
                    double savedMoney = double.Parse(Console.ReadLine());
                    moneyNeeded -= savedMoney;
                }
                Console.WriteLine($"Going to {destinationCommand}!");
                destinationCommand = Console.ReadLine();
            }
        }
    }
}
