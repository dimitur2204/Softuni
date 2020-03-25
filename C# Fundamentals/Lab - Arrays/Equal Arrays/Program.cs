using System;
using System.Linq;

namespace Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] secondArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int diffIndex = 0;
            bool isElementSame = true;
            int sum = 0;
            for (int i = 0; i < firstArray.Length; i++)
            {               
                if (firstArray[i] != secondArray[i])
                {
                    isElementSame = false;
                    diffIndex = i;
                    break;
                }
                sum += firstArray[i];
            }
            if (isElementSame)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
            else
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {diffIndex} index");
            }
        }
    }
}

