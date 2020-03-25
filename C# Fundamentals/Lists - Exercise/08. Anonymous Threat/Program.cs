using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = Console.ReadLine()
        .Split()
        .ToList();
            string command = Console.ReadLine();
            while (command != "3:1")
            {
                string[] commandSeparated = command.Split();
                if (commandSeparated[0] == "merge")
                {
                    int startIndex = int.Parse(commandSeparated[1]);
                    int endIndex = int.Parse(commandSeparated[2]);
                    if (startIndex < 0 && endIndex >= strings.Count)
                    {
                        strings = Merge(0, strings.Count - 1, strings);
                    }
                    else if (startIndex >= strings.Count)
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    else if (endIndex < 0)
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    else if (endIndex >= strings.Count)
                    {
                        strings = Merge(startIndex, strings.Count - 1, strings);
                    }
                    else if (startIndex < 0)
                    {
                        strings = Merge(0, endIndex, strings);
                    }

                    else
                    {
                        strings = Merge(startIndex, endIndex, strings);
                    }
                }
                else
                {
                    int divideIndex = int.Parse(commandSeparated[1]);
                    int partitions = int.Parse(commandSeparated[2]);
                    Divide(divideIndex, partitions, strings);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", strings));
        }

        private static List<string> Divide(int divideIndex, int partitions, List<string> strings)
        {
            List<string> divided = new List<string>();
            string wordToDivide = strings[divideIndex];
            strings.RemoveAt(divideIndex);
            int lettersPerPartiotion = wordToDivide.Length / partitions;
            for (int i = 0; i < partitions; i++)
            {
                if (i == partitions - 1)
                {
                    divided.Add(wordToDivide.Substring(i * lettersPerPartiotion));
                }
                else
                {
                    divided.Add(wordToDivide.Substring(i * lettersPerPartiotion, lettersPerPartiotion));
                }
            }
            strings.InsertRange(divideIndex, divided);
            return strings;
        }

        private static List<string> Merge(int startIndex, int endIndex, List<string> strings)
        {
            List<string> stringsToConcat = strings.GetRange(startIndex + 1, endIndex - startIndex);
            foreach (var item in stringsToConcat)
            {
                strings[startIndex] += item;
            }
            strings.RemoveRange(startIndex + 1, endIndex - startIndex);
            return strings;
        }
    }
}
