using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var elements = new HashSet<string>();
            for (int i = 0; i < rows; i++)
            {
                var inputEle = Console.ReadLine().Split();
                foreach (var item in inputEle)
                {
                    elements.Add(item);
                }
            }
            Console.WriteLine(String.Join(" ",elements.OrderBy(x => x)));
        }
    }
}
