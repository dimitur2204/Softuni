using System;
using System.Collections;

namespace Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringToReverse = Console.ReadLine();
            var result = new Stack();
            foreach (var letter in stringToReverse)
            {
                result.Push(letter);
            }
            while (result.Count > 0)
            {
                Console.Write(result.Pop());
            }
        }
    }
}
