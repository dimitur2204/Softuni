using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._List_Operations
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
            while (command != "End")
            {
                string[] commandSeparated = command.Split();
                if (commandSeparated[0] == "Add")
                {
                    numbers.Add(int.Parse(commandSeparated[1]));
                }
                else if (commandSeparated[0] == "Insert")
                {
                    if (IsIndexValid(numbers, int.Parse(commandSeparated[2])))
                    {
                        numbers.Insert(int.Parse(commandSeparated[2]), int.Parse(commandSeparated[1]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }                   
                }
                else if (commandSeparated[0] == "Remove")
                {
                    if (IsIndexValid(numbers, int.Parse(commandSeparated[1])))
                    {
                        numbers.RemoveAt(int.Parse(commandSeparated[1]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (commandSeparated[0] == "Shift")
                {
                    if (commandSeparated[1] == "left")
                    {
                       numbers = ShiftLeft(numbers, int.Parse(commandSeparated[2]));
                    }
                    else
                    {
                        numbers = ShiftRight(numbers, int.Parse(commandSeparated[2]));
                    }
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", numbers));
        }
        static bool IsIndexValid(List<int> numbers, int index) 
        {
            if (index >= 0 && index < numbers.Count)
            {
                return true;
            }
            else 
            { 
                return false;
            }
        }
        static List<int> ShiftLeft(List<int> numbers, int count) 
        {
            for (int i = 0; i < count; i++)
            {
                numbers.Add(numbers[0]);
                numbers.RemoveAt(0);
            }
            return numbers
                ;
        }

        static List<int> ShiftRight(List<int> numbers, int count)
        {
            for (int i = 0; i < count; i++)
            {
                numbers.Insert(0, numbers[numbers.Count - 1]);
                numbers.RemoveAt(numbers.Count - 1);
            }
            return numbers
                ;
        }
    }
}
