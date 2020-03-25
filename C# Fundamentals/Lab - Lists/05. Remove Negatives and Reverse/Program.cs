using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> positiveNumbers = new List<int>();
            for (int n = 0; n < numbers.Count; n++)
            {
                if (numbers[n] >= 0)
                {
                    positiveNumbers.Add(numbers[n]);
                }
            }
            positiveNumbers.Reverse();
            if (positiveNumbers.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                Console.WriteLine(String.Join(" ", positiveNumbers));
            }
        }
    }
}
