using System;

namespace Christmas_Decoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int budgetForDecorations = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            
            while (command != "Stop")
            {
                int moneyNeeded = 0;
                for (int character = 0; character < command.Length; character++)
                {
                    int asciiNumber = (int)command[character];
                    moneyNeeded = moneyNeeded + asciiNumber;
                }
                if (moneyNeeded <= budgetForDecorations)
                {
                    Console.WriteLine("Item successfully purchased!");
                    budgetForDecorations -= moneyNeeded;
                }
                else if (budgetForDecorations < moneyNeeded)
                {
                    Console.WriteLine("Not enough money!");
                    return;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Money left: {budgetForDecorations}");
        }
    }
}
