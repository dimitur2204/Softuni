using System;
using System.Collections.Generic;
using System.Linq;

namespace Battle_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();
            var players = new Dictionary<string, int[]>();
            while (command != "Results")
            {
                var tokens = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Add")
                {
                    var username = tokens[1];
                    var health = int.Parse(tokens[2]);
                    var energy = int.Parse(tokens[3]);
                    if (!players.ContainsKey(username))
                    {
                        players.Add(username, new int[] { health, energy });
                    }
                    else
                    {
                        players[username][0] += health;
                    }
                }
                else if (tokens[0] == "Attack")
                {
                    var attacker = tokens[1];
                    var defender = tokens[2];
                    var damage = int.Parse(tokens[3]);
                    if (players.ContainsKey(attacker) && players.ContainsKey(defender))
                    {
                        players[defender][0] -= damage;
                        players[attacker][1]--;
                    }
                    else
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    if (players[defender][0] <= 0)
                    {
                        players.Remove(defender);
                        Console.WriteLine($"{defender} was disqualified!");
                    }
                    if (players[attacker][1] <= 0)
                    {
                        players.Remove(attacker);
                        Console.WriteLine($"{attacker} was disqualified!");
                    }
                }
                else if (tokens[0] == "Delete")
                {
                    var username = tokens[1];
                    if (username == "All")
                    {
                        players.Clear();
                    }
                    else 
                    {
                        if (players.ContainsKey(username))
                        {
                            players.Remove(username);
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"People count: {players.Count}");
            players = players
                .OrderByDescending(x => x.Value[0])
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var player in players)
            {
                Console.WriteLine($"{player.Key} - {player.Value[0]} - {player.Value[1]}");
            }
        }
    }
}
