using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
    .Split()
    .Select(x => int.Parse(x))
    .ToArray();
            var n = input[0];
            var s = input[1];
            var x = input[2];
            var stack = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x)));
            for (int i = 0; i < s; i++)
            {
                stack.Dequeue();
            }
            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    var min = int.MaxValue;
                    while (stack.Count > 0)
                    {
                        min = Math.Min(min, stack.Dequeue());
                    }
                    Console.WriteLine(min);
                }
            }
        }
    }
}
