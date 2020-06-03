using System;
using System.Collections.Generic;
using System.Linq;

namespace Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray();
            var stack = new Stack<int>();
            foreach (var item in input)
            {
                stack.Push(item);
            }
            var capacity = int.Parse(Console.ReadLine());
            var numberOfRacks = 1;
            var sumOfClothes = 0;
            while (stack.Count > 0)
            {
                if (stack.Peek()+sumOfClothes > capacity)
                {
                    sumOfClothes = 0;
                    numberOfRacks++;
                }
                else
                {
                    sumOfClothes += stack.Pop();
                }
            }
            Console.WriteLine(numberOfRacks);
        }
    }
}
