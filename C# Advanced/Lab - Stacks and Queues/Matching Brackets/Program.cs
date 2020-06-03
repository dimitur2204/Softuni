using System;
using System.Collections;

namespace Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var brackets = new Stack();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    brackets.Push(i);
                }
                if (input[i] == ')')
                {
                     var start = (int)brackets.Pop();
                    Console.WriteLine(input.Substring(start,i - start + 1));
                }
            }
        }
    }
}
