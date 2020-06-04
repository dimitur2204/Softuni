using System;
using System.Collections.Generic;
using System.Linq;

namespace The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var vloggers = new Dictionary<string, HashSet<string>>();
            var input = Console.ReadLine();
            while (input != "Statistics")
            {
                var tokens = input.Split();
                var command = tokens[1];
                var vloggerName = tokens[0];
                if (command == "joined")
                {
                    if (!vloggers.ContainsKey(vloggerName))
                    {
                        vloggers.Add(vloggerName, new HashSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    var vloggerToFollow = tokens[2];
                    if (vloggers.ContainsKey(vloggerToFollow) && vloggers.ContainsKey(vloggerName) && vloggerToFollow != vloggerName)
                    {
                        vloggers[vloggerToFollow].Add(vloggerName);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            vloggers = vloggers
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => GetFollowing(x.Key,vloggers))
                .ToDictionary(x => x.Key, x=> x.Value);
            var place = 1;
            foreach (var (vlogger,followers) in vloggers)
            {
                Console.WriteLine($"{place}. {vlogger} : {followers.Count} followers, {GetFollowing(vlogger, vloggers)} following");
                if (place == 1)
                {
                    foreach (var follower in followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                place++;
            }
        }

        private static int GetFollowing(string vlogger, Dictionary<string, HashSet<string>> vloggers)
        {
            var following = 0;
            foreach (var (vloggerName,followers) in vloggers)
            {
                foreach (var follower in followers)
                {
                    if (follower == vlogger)
                    {
                        following++;
                    }
                }
            }
            return following;
        }
    }
}
