using System;
using System.Collections;
using System.Linq;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ");
            var stack = new Stack();
            foreach (var character in input.Reverse())
            {
                stack.Push(character);
            }
            var sum = int.Parse(stack.Pop().ToString());
            while (stack.Count > 0)
            {
                var oper = (string)stack.Pop();
                var digit = int.Parse(stack.Pop().ToString());
                if (oper == "+")
                {
                    sum += digit;
                }
                else
                {
                    sum -= digit;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
