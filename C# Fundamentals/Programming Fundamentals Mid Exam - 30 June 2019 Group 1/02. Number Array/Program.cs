using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Number_Array
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
                string givenCommand = commandSeparated[0];
                if (givenCommand == "Switch")
                {
                    int index = int.Parse(commandSeparated[1]);
                    if (IsIndexValid(index, numbers))
                    {
                        SwitchSign(index, numbers);
                    }
                }
                else if (givenCommand == "Change")
                {
                    int index = int.Parse(commandSeparated[1]);
                    int value = int.Parse(commandSeparated[2]);
                    if (IsIndexValid(index, numbers))
                    {
                        Change(index, value, numbers);
                    }             
                }
                else if (givenCommand == "Sum")
                {
                    if (commandSeparated[1] == "Negative")
                    {
                        Console.WriteLine(SumNegative(numbers)); 
                    }
                    else if (commandSeparated[1] == "Positive")
                    {
                        Console.WriteLine(SumPositive(numbers)); 
                    }
                    else
                    {
                        Console.WriteLine(numbers.Sum()); 
                    }
                }
                command = Console.ReadLine();
            }
            List<int> positive = numbers.FindAll(x => x >= 0);
            Console.WriteLine(String.Join(" ", positive));
        }

        private static int SumPositive(List<int> numbers)
        {
            List<int> positiveNumbers = numbers.FindAll(x => x >= 0);
            return positiveNumbers.Sum();
        }

        private static int SumNegative(List<int> numbers)
        {
            List<int> negativeNumbers = numbers.FindAll(x => x < 0);
            return negativeNumbers.Sum();
        }

        private static void Change(int index, int value, List<int> numbers)
        {
            numbers[index] = value;
        }

        private static void SwitchSign(int index, List<int> numbers)
        {
            numbers[index] -= numbers[index] * 2;
        }

        private static bool IsIndexValid(int index, List<int> numbers)
        {
            if (index < 0 || index >= numbers.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
