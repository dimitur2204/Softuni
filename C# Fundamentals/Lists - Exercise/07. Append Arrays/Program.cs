using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separators = {'|' };

            List<string> allLists = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToList();
            List<int> numbers = new List<int>();
            foreach (var str in allLists)
            {
                numbers.AddRange(str
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList());
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
