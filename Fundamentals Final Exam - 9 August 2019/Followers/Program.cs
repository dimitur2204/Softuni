using System;
using System.Collections.Generic;
using System.Linq;

namespace Followers
{
    public class Follower
    {
        public int Likes { get; set; }
        public int Comments { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var followers = new Dictionary<string, Follower>();
            var command = Console.ReadLine();
            while (command != "Log out")
            {
                var tokens = command
                    .Split(": ",StringSplitOptions.RemoveEmptyEntries);
                var username = tokens[1];
                if (tokens[0] == "New follower")
                {
                    if (!followers.ContainsKey(username))
                    {
                        var follower = new Follower();
                        followers.Add(username, follower);
                    }
                }
                else if (tokens[0] == "Like")
                {
                    var count = int.Parse(tokens[2]);
                    if (!followers.ContainsKey(username))
                    {
                        var follower = new Follower();
                        follower.Likes += count;
                        followers.Add(username, follower);
                    }
                    else
                    {
                        followers[username].Likes += count;
                    }
                }
                else if (tokens[0] == "Comment")
                {
                    if (!followers.ContainsKey(username))
                    {
                        var follower = new Follower();
                        follower.Comments++;
                        followers.Add(username, follower);
                    }
                    else
                    {
                        followers[username].Comments++;
                    }
                }
                else if (tokens[0] == "Blocked")
                {
                    if (!followers.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                    else
                    {
                        followers.Remove(username);
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{followers.Count} followers");
            followers = followers
                .OrderByDescending(x => x.Value.Likes)
                .ThenBy(x => x.Key)
                .ToDictionary(x=>x.Key,x=>x.Value);
            foreach (var follower in followers)
            {
                Console.WriteLine($"{follower.Key}: {follower.Value.Comments + follower.Value.Likes}");
            }
        }
    }
}
