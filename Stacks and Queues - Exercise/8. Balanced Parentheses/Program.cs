using System;
using System.Collections.Generic;

namespace Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();
            var isBalanced = true;
            foreach (var item in input)
            {
                if (item == '(' || item == '[' || item == '{')
                {
                    stack.Push(item);
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        if (item == ')')
                        {
                            if (stack.Peek() == '(')
                            {
                                stack.Pop();
                            }
                            else
                            {
                                isBalanced = false;
                                break;
                            }
                        }
                        if (item == ']')
                        {
                            if (stack.Peek() == '[')
                            {
                                stack.Pop();
                            }
                            else
                            {
                                isBalanced = false;
                                break;
                            }
                        }
                        if (item == '}')
                        {
                            if (stack.Peek() == '{')
                            {
                                stack.Pop();
                            }
                            else
                            {
                                isBalanced = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }
            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
