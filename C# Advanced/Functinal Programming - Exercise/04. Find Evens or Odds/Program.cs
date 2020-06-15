using System;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            var bounds = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var lowerBound = bounds[0];
            var upperBound = bounds[1];
            var criteria = Console.ReadLine();
            Predicate<int> predicate = null;
            if (criteria == "odd")
            {
                predicate = (x) => x % 2 != 0;
            }
            else if (criteria == "even")
            {
                predicate = (x) => x % 2 == 0;
            }
            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (predicate(i))
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
