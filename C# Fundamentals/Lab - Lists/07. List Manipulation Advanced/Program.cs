using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();
            string command = Console.ReadLine();
            bool changes = false;
            while (command != "end")
            {
                string[] commandSeparated = command.Split();
                if (commandSeparated[0] == "Contains")
                {
                    if (numbers.Contains(int.Parse(commandSeparated[1])))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (commandSeparated[0] == "Add")
                {
                    numbers.Add(int.Parse(commandSeparated[1]));
                    changes = true;
                }
                else if (commandSeparated[0] == "Remove")
                {
                    numbers.Remove(int.Parse(commandSeparated[1]));
                    changes = true;
                }
                else if (commandSeparated[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(commandSeparated[1]));
                    changes = true;
                }
                else if (commandSeparated[0] == "Insert")
                {
                    numbers.Insert(int.Parse(commandSeparated[2]), int.Parse(commandSeparated[1]));
                    changes = true;
                }
                else if (commandSeparated[0] == "PrintEven")
                {
                    PrintEven(numbers);
                }
                else if (commandSeparated[0] == "PrintOdd")
                {
                    PrintOdd(numbers);
                }
                else if (commandSeparated[0] == "GetSum")
                {
                    Console.WriteLine(numbers.Sum()); 
                }
                else if (commandSeparated[0] == "Filter")
                {
                    Filter(commandSeparated[1], int.Parse(commandSeparated[2]), numbers);
                }
                command = Console.ReadLine();
            }
            if (changes)
            {
                Console.WriteLine(String.Join(" ", numbers));
            }
        }

        private static void Filter(string v1, int v2, List<int> numbers)
        {
            if (v1 == ">")
            {
                foreach (var item in numbers)
                {
                    if (item > v2)
                    {
                        Console.Write(item + " ");
                    }
                }
                Console.WriteLine();
            }
            else if (v1 == ">=")
            {
                foreach (var item in numbers)
                {
                    if (item >= v2)
                    {
                        Console.Write(item + " ");
                    }
                }
                Console.WriteLine();
            }
            else if (v1 == "<")
            {
                foreach (var item in numbers)
                {
                    if (item < v2)
                    {
                        Console.Write(item + " ");
                    }
                }
                Console.WriteLine();
            }
            else if (v1 == "<=")
            {
                foreach (var item in numbers)
                {
                    if (item <= v2)
                    {
                        Console.Write(item + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        static void PrintEven(List<int> numbers) 
        {
            foreach (var item in numbers)
            {
                if (item % 2 == 0)
                {
                    Console.Write(item + " ");
                }                
            }
            Console.WriteLine();
        }

        static void PrintOdd(List<int> numbers)
        {
            foreach (var item in numbers)
            {
                if (item % 2 == 1)
                {
                    Console.Write(item + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
