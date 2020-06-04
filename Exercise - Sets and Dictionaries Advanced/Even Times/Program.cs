using System;
using System.Collections.Generic;

namespace Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfInputs = int.Parse(Console.ReadLine());
            var numbers = new Dictionary<int, int>();
            for (int i = 0; i < numberOfInputs; i++)
            {
                var number = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(number))
                {
                    numbers.Add(number,0);
                }
                numbers[number]++;
            }
            foreach (var (key,value) in numbers)
            {
                if (value % 2 == 0)
                {
                    Console.WriteLine(key);
                }
            }
        }
    }
}
