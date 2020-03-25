using System;

namespace Cookie_factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfOrders = int.Parse(Console.ReadLine());
            for (int orderNumber = 1; orderNumber <= numberOfOrders; orderNumber++)
            {
                string inputCommand = Console.ReadLine();
                bool flour = false;
                bool sugar = false;
                bool eggs = false;
                while (inputCommand != "Bake!")
                {                    

                    if (inputCommand == "flour")
                    {
                        flour = true;
                    }
                    if (inputCommand == "sugar")
                    {
                        sugar = true;
                    }
                    if (inputCommand == "eggs")
                    {
                        eggs = true;
                    }                    
                    inputCommand = Console.ReadLine();
                }
                while (flour == false || sugar == false || eggs == false)
                {
                    Console.WriteLine("The batter should contain flour, eggs and sugar!");
                    inputCommand = Console.ReadLine();
                    while (inputCommand != "Bake!")
                    {

                        if (inputCommand == "flour")
                        {
                            flour = true;
                        }
                        if (inputCommand == "sugar")
                        {
                            sugar = true;
                        }
                        if (inputCommand == "eggs")
                        {
                            eggs = true;
                        }
                        inputCommand = Console.ReadLine();
                    }
                }
                Console.WriteLine($"Baking batch number {orderNumber}...");
            }
        }
    }
}
