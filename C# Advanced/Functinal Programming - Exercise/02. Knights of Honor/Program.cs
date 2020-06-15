using System;
using System.Dynamic;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printSir = Print;
            printSir(Console.ReadLine());
        }

        private static void Print(string input)
        {
            input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .Select(x => "Sir " + x)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
