using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfOperations = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            for (int n = 0; n < numberOfOperations; n++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var command = input[0];
                if (command == 1)
                {
                    stack.Push(input[1]);
                }
                else if (command == 2)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else if (command == 3)
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(MaxElement(stack));
                    }
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(MinElement(stack));
                    }
                }
            }
            Console.WriteLine(String.Join(", ",stack));
        }
        static int MaxElement(Stack<int> collection) 
        {
            var stackCopy = new Stack<int>(collection);
            var max = int.MinValue;
            while (stackCopy.Count > 0)
            {
                max = Math.Max(max, stackCopy.Pop());
            }
            return max;
        }
        static int MinElement(Stack<int> collection) 
        {
            var stackCopy = new Stack<int>(collection);
            var min = int.MaxValue;
            while (stackCopy.Count > 0)
            {
                min = Math.Min(min, stackCopy.Pop());
            }
            return min;
        }
    }
}
