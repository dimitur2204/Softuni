using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3._Tanks_Collector
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> ownedTanks = Console.ReadLine()
                            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                            .ToList();
            int numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                string command = Console.ReadLine();
                string[] tokens = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Add")
                {
                    if (ownedTanks.Contains(tokens[1]))
                    {
                        Console.WriteLine("Tank is already bought");
                    }
                    else
                    {
                        ownedTanks.Add(tokens[1]);
                        Console.WriteLine("Tank successfully bought");
                    }
                }
                else if (tokens[0] == "Remove")
                {
                    if (ownedTanks.Contains(tokens[1]))
                    {
                        ownedTanks.Remove(tokens[1]);
                        Console.WriteLine("Tank successfully sold");
                    }
                    else
                    {
                        Console.WriteLine("Tank not found");
                    }
                }
                else if (tokens[0] == "Remove At")
                {
                    int index = int.Parse(tokens[1]);
                    if (IsIndexValid(index,ownedTanks))
                    {
                        ownedTanks.RemoveAt(index);
                        Console.WriteLine("Tank successfully sold");
                    }
                    else
                    {
                        Console.WriteLine("Index out of range");
                    }
                }
                else if (tokens[0] == "Insert")
                {
                    int index = int.Parse(tokens[1]);
                    if (IsIndexValid(index, ownedTanks))
                    {
                        if (ownedTanks.Contains(tokens[2]))
                        {
                            Console.WriteLine("Tank is already bought");
                        }
                        else
                        {
                            ownedTanks.Insert(index, tokens[2]);
                            Console.WriteLine("Tank successfully bought");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Index out of range");
                    }
                }               
            }
            Console.WriteLine(String.Join(", ", ownedTanks));
        }
        static bool IsIndexValid(int index, List<string> list) 
        {
            if (index < 0 || index >= list.Count)
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
