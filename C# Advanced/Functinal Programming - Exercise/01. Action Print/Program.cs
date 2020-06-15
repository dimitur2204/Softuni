using System;
using System.Dynamic;
using System.Linq;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printStrings = Print;
            printStrings(Console.ReadLine());
        }

        private static void Print(string input)
        {
            input.Split().ToList().ForEach(Console.WriteLine);
        }
    }
}
