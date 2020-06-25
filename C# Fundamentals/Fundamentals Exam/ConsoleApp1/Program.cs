using System;
using System.Collections.Generic;
using System.Linq;

namespace Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            var cities = new Dictionary<string, int[]>();
            var command = Console.ReadLine();
            while (command != "Sail")
            {
                var tokens = command.Split("||",StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[0];
                var gold = int.Parse(tokens[1]);
                var pop = int.Parse(tokens[2]);
                if (cities.ContainsKey(name))
                {
                    cities[name][1] += pop;
                    cities[name][0] += gold;
                }
                else
                {
                    cities.Add(name, new int[] { gold, pop });
                }
                command = Console.ReadLine();
            }
            command = Console.ReadLine();
            while (command != "End")
            {
                var tokens = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Plunder")
                {
                    var town = tokens[1];
                    var pop = int.Parse(tokens[2]);
                    var gold = int.Parse(tokens[3]);
                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {pop} citizens killed.");
                    cities[town][0] -= pop;
                    cities[town][1] -= gold;
                    if (cities[town][1] <= 0 || cities[town][0] <= 0)
                    {
                        Console.WriteLine($"{town} has been wiped off the map!");
                        cities.Remove(town);
                    }
                }
                else
                {
                    var town = tokens[1];
                    var gold = int.Parse(tokens[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        cities[town][1] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cities[town][1]} gold.");
                    }
                }
                command = Console.ReadLine();
            }
            cities = cities
                .OrderByDescending(x => x.Value[1])
                .ThenBy(x => x.Key)
                .ToDictionary(x=>x.Key,x=>x.Value);
            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (var city in cities)
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value[0]} citizens, Gold: {city.Value[1]} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
