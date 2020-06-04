using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" -> ");
                var color = input[0];
                var clothes = input[1].Split(',', StringSplitOptions.RemoveEmptyEntries);
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color,new Dictionary<string, int>());
                }
                foreach (var item in clothes)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color].Add(item,0);
                    }
                    wardrobe[color][item]++;
                }
            }
            var itemToSearch = Console.ReadLine().Split();
            var colorToSearch = itemToSearch[0];
            var clothingToSearch = itemToSearch[1];
            foreach (var (key,value) in wardrobe)
            {
                Console.WriteLine($"{key} clothes:");
                foreach (var item in value)
                {
                    if (key == colorToSearch && item.Key == clothingToSearch)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
