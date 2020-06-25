using System;
using System.Collections.Generic;
using System.Linq;

namespace Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var hallMaxCap = int.Parse(Console.ReadLine());
            var halls = new Queue<Tuple<char,int>>();
            var input = new Stack<char>(Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse));
            while (input.Any())
            {
                var item = input.Pop();
                if (char.IsDigit(item))
                {
                    var value = int.Parse(item.ToString());
                    var hallValue = halls.Peek().Item2;
                    if (hallValue + value <= hallMaxCap)
                    {
                        halls.Peek().Item2 += value;
                    }
                }
                else
                {
                    halls.Enqueue(new Tuple<char, int>(item,0));
                }
            }
        }
    }
}
