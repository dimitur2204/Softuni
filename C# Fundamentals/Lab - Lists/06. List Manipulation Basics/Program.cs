using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
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
            while (command != "end")
            {
                string[] commandSeparated = command.Split();
                if (commandSeparated[0] == "Add")
                {
                    numbers.Add(int.Parse(commandSeparated[1]));
                }
                else if (commandSeparated[0] == "Remove")
                {
                    numbers.Remove(int.Parse(commandSeparated[1]));
                }
                else if (commandSeparated[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(commandSeparated[1]));
                }
                else if (commandSeparated[0] == "Insert")
                {
                    numbers.Insert(int.Parse(commandSeparated[2]), int.Parse(commandSeparated[1]));
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
