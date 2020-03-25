using System;

namespace Name_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameCommand = Console.ReadLine();
            int maxPoints = int.MinValue;
            string nameOfWinner = "";
            while (nameCommand != "STOP")
            {
                int currentSum = 0;
                for (int position = 0; position < nameCommand.Length; position++)
                {
                    currentSum += nameCommand[position];
                }
                if (currentSum > maxPoints)
                {
                    maxPoints = currentSum;
                    nameOfWinner = nameCommand;
                }
                nameCommand = Console.ReadLine();
            }
            Console.WriteLine($"Winner is {nameOfWinner} - {maxPoints}!");
        }
    }
}
