﻿using System;
using System.Linq;

namespace Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers =
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int sumOfEven = 0;
            int sumOfOdd = 0;
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    sumOfEven += number;
                }
                else
                {
                    sumOfOdd += number;
                }
            }
            Console.WriteLine(sumOfEven - sumOfOdd);
        }
    }
}
