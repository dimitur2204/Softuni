using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> bomb = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int bombNumber = bomb[0];
            int power = bomb[1];
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombNumber )
                {
                    numbers = Detonate(numbers, power, i, bombNumber);
                    i--;

                }
            }
            Console.WriteLine(numbers.Sum());
        }

        private static List<int> Detonate(List<int> numbers, int power, int bombNumberIndex, int bombNumber)
        {
            if (bombNumberIndex + power >= numbers.Count && bombNumberIndex - power < 0)
            {
                numbers.RemoveRange(0, numbers.Count);
            }
            else if (bombNumberIndex + power >= numbers.Count)
            {
                numbers.RemoveRange(bombNumberIndex - power, numbers.Count - bombNumberIndex + power );
            }
            else if (bombNumberIndex - power < 0)
            {
                numbers.RemoveRange(0, bombNumberIndex + power + 1);
            }
            else
            {
                numbers.RemoveRange(bombNumberIndex - power, power * 2 + 1);
            }
            return numbers;
        }
    }
}
