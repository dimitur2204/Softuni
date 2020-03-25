using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
        .Split("|", StringSplitOptions.RemoveEmptyEntries)
        .ToList();
            string command = Console.ReadLine();
            while (command != "Yohoho!")
            {
                string[] commandSeparated = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commandSeparated[0] == "Loot")
                {
                    items = Loot(commandSeparated, items);
                }
                else if (commandSeparated[0] == "Drop")
                {
                    int index = int.Parse(commandSeparated[1]);
                    if (index < 0 || index >= items.Count)
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        string bazikateLiSe = items.ElementAt(index);
                        items.RemoveAt(index);
                        items.Add(bazikateLiSe);
                    }

                }
                else if (commandSeparated[0] == "Steal")
                {
                    int count = int.Parse(commandSeparated[1]);
                    Steal(count, items);
                }
                command = Console.ReadLine();
            }
            if (items.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                double sum = 0.0;
                foreach (var item in items)
                {
                    sum += item.Length;
                }
                double average = sum / items.Count;
                Console.WriteLine($"Average treasure gain: {average:f2} pirate credits."); 
            }
        }

        private static void Steal(int count, List<string> items)
        {
            List<string> stolen = new List<string>();
            if (count > items.Count - 1)
            {
                stolen = items.GetRange(0, items.Count);
                items.RemoveRange(0,items.Count);
            }
            else
            {
            stolen = items.GetRange(items.Count -  count, count);
            items.RemoveRange(items.Count -  count, count);
            }
            Console.WriteLine(String.Join(", ",stolen));
        }

        static List<string> Loot(string[] itemsToAdd, List<string> items) 
        {
            for (int i = 1; i < itemsToAdd.Length; i++)
            {
                if (items.Contains(itemsToAdd[i]))
                {
                    continue;
                }
                else
                {
                    items.Insert(0, itemsToAdd[i]);
                }
            }
            return items;
        }
    }
    
}
