using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            var racers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var kmRan = new Dictionary<string, int>();
            foreach (var racer in racers)
            {
                kmRan.Add(racer,0);
            }
            var command = Console.ReadLine();
            while (command != "end of race")
            {
                var nameInChar = Regex.Matches(command, @"[A-Za-z]");
                var name = String.Join("", nameInChar);
                var kilometersInChar = Regex.Matches(command, @"\d");
                var kilometers = 0;
                foreach (var km in kilometersInChar)
                {
                    kilometers += int.Parse(km.ToString());
                }
                if (kmRan.ContainsKey(name))
                {
                    kmRan[name] += kilometers;
                }
                command = Console.ReadLine();
            }
           kmRan = kmRan
                .OrderByDescending(x => x.Value)
                .Take(3)
                .ToDictionary(x => x.Key, x => x.Value);
            var place = 1;
            foreach (var player in kmRan)
            {
                if (place == 1)
                {
                    Console.WriteLine($"{place}st place: {player.Key}");
                }
                else if (place == 2)
                {
                    Console.WriteLine($"{place}nd place: {player.Key}");
                }
                else
                {
                    Console.WriteLine($"{place}rd place: {player.Key}");
                }
                place++;
            }
        }
    }
}
