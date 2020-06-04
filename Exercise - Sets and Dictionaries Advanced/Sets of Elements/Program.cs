using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = input[0];
            var m = input[1];
            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();
            var overlappingEle = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                var number = int.Parse(Console.ReadLine());
                firstSet.Add(number);
            }
            for (int i = 0; i < m; i++)
            {
                var number = int.Parse(Console.ReadLine());
                secondSet.Add(number);
            }
            foreach (var item in firstSet)
            {
                if (secondSet.Contains(item))
                {
                    overlappingEle.Add(item);
                }
                
            }
            Console.WriteLine(String.Join(" ", overlappingEle));
        }
    }
}
