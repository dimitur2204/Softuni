using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Word_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();
            Console.WriteLine(String.Join("\n", words.Where(x => x.Length%2 == 0)));
        }
    }
}
