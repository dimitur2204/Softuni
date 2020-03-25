using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Nikulden_s_meals
{
    class Program
    {
        static void Main(string[] args)
        {
            var guests = new Dictionary<string,List<string>>();
            var command = Console.ReadLine();
            var count = 0;
            while (command != "Stop")
            {
                var tokens = command.Split("-", StringSplitOptions.RemoveEmptyEntries);
                var guest = tokens[1];
                var meal = tokens[2];
                if (tokens[0] == "Like")
                {
                    if (guests.ContainsKey(guest))
                    {
                        if (!(guests[guest].Contains(meal)))
                        {
                            guests[guest].Add(meal);
                        }
                    }
                    else
                    {
                        guests.Add(guest,new List<string>{ meal});
                    }
                }
                else
                {
                    if (guests.ContainsKey(guest))
                    {
                        if (guests[guest].Contains(meal))
                        {
                            guests[guest].Remove(meal);
                            Console.WriteLine($"{guest} doesn't like the {meal}.");
                            count++;
                        }
                        else
                        {
                            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                }
                command = Console.ReadLine();
            }
            foreach (var guest in guests
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{guest.Key}: {String.Join(", ", guest.Value)}");
            }
            Console.WriteLine($"Unliked meals: {count}");
        }
    }
}
