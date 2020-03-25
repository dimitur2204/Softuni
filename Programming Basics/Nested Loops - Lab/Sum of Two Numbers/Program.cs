using System;

namespace Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int startOfInterval = int.Parse(Console.ReadLine());
            int endOfInterval = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int counterOfCombinations = 0;            
            for (int i = startOfInterval; i <= endOfInterval; i++)
            {
                for (int j = startOfInterval; j <= endOfInterval; j++)
                {
                    counterOfCombinations++;
                    int sum = i + j;
                    if (sum == magicNumber)
                    {
                        Console.WriteLine($"Combination N: {counterOfCombinations}");
                        Console.WriteLine($"{i} + {j} = {magicNumber}");
                        return;
                    }
                }
            }
            Console.WriteLine($"{counterOfCombinations} combinations - neither equals {magicNumber}");
        }
    }
}
