using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Action<List<int>> add = (l) => list = list.Select(e => e + 1).ToList();
            Action<List<int>> multiply = (l) => list = list.Select(e => e * 2).ToList();
            Action<List<int>> subtract = (l) => list = list.Select(e => e - 1).ToList();
            Action<List<int>> print = (l) => {
                foreach (var item in l)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            };
            var command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "add")
                {
                    add(list);
                }
                else if (command == "multiply")
                {
                    multiply(list);
                }
                else if (command == "subtract")
                {
                    subtract(list);
                }
                else if (command == "print")
                {
                    print(list);
                }
                command = Console.ReadLine();
            }
        }
    }
}
