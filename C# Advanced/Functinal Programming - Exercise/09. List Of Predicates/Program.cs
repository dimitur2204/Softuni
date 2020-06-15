using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            Func<int, int, bool> checkForDivisibility = (n, d) => n % d == 0;
            Func<int, List<int>, bool> checkForWholeList = (n, d) =>
            {
                foreach (var item in d)
                {
                    if (!checkForDivisibility(n, item))
                    {
                        return false;
                    }
                }
                return true;
            };
            var output = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                if (checkForWholeList(i,numbers))
                {
                    output.Add(i);
                }
            }
            foreach (var item in output)
            {
                Console.Write(item + " ");
            }
        }
    }
}
