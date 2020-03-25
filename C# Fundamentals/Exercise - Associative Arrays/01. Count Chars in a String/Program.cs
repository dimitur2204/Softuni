using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = Console.ReadLine()
                .Split()
                .ToList();
            Dictionary<char, int> charsInString = new Dictionary<char, int>();
            foreach (var word in strings)
            {
                foreach (var character in word)
                {
                    if (charsInString.ContainsKey(character))
                    {
                        charsInString[character]++;
                    }
                    else
                    {
                        charsInString.Add(character, 1);
                    }
                }
            }
            foreach (var item in charsInString)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
