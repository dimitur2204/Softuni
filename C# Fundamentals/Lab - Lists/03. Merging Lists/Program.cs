using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> list2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> mergedList = new List<int>();
            int cycleLength = Math.Max(list1.Count, list2.Count);
            for (int i = 0; i < cycleLength; i++)
            {
                if (!(i >= list1.Count))
                {
                    mergedList.Add(list1[i]);
                }

                if (!(i >= list2.Count))
                {
                    mergedList.Add(list2[i]);
                }
            }
            Console.WriteLine(String.Join(" ", mergedList));
        }
    }
}
