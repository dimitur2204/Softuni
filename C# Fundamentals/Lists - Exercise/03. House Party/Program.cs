using System;
using System.Collections.Generic;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> names = new List<string>();
            
            for (int i = 0; i < numberOfCommands ; i++)
            {
                string command = Console.ReadLine();
                string[] commandSeparated = command
                    .Split();
                if (commandSeparated[2] == "not")
                {
                    if (names.Contains(commandSeparated[0]))
                    {
                        names.Remove(commandSeparated[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{commandSeparated[0]} is not in the list!");
                    }
                }
                else
                {
                    if (names.Contains(commandSeparated[0]))
                    {
                        Console.WriteLine($"{commandSeparated[0]} is already in the list!");
                    }
                    else
                    {
                        names.Add(commandSeparated[0]);
                    }
                }
            }
            Console.WriteLine(String.Join("\n", names));
        }
    }
}
