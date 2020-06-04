using System;
using System.Collections.Generic;

namespace Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var symbols = new SortedDictionary<char, int>();
            var input = Console.ReadLine();
            foreach (var character in input)
            {
                if (!symbols.ContainsKey(character))
                {
                    symbols.Add(character,0);
                }
                symbols[character]++;
            }
            foreach (var (key,value) in symbols)
            {
                Console.WriteLine($"{key}: {value} time/s");
            }
        }
    }
}
