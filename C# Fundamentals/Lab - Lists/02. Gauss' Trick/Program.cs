using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Gauss__Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();
            List<double> summed = new List<double>();
            for (int i = 0; i < numbers.Count/2; i++)
            {
                summed.Add(numbers[i] + numbers[numbers.Count - 1 - i]);
            }
            
            if (numbers.Count % 2 == 1)
            {
                summed.Add(numbers[numbers.Count / 2]);
            }

            Console.WriteLine(String.Join(" ", summed));
        }
    }
}
