using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> legendary = new Dictionary<string, int>
            {
                { "shards", 0},
                {"fragments", 0},
                { "motes", 0}
            };
            Dictionary<string, int> junk = new Dictionary<string, int>();
            List<string> input1 = Console.ReadLine()
                .Split()
                .ToList();
            while (true)
            {
                bool win = false;
                var input = input1.Select(x => x.ToLower()).ToList();
                for (int i = 0; i < input.Count - 1; i += 2)
                {
                    if (input[i + 1] == "shards")
                    {
                        legendary["shards"] += int.Parse(input[i]);

                        if (legendary["shards"] >= 250)
                        {
                            legendary["shards"] -= 250;
                            Console.WriteLine("Shadowmourne obtained!");
                            win = true;
                            break;
                        }
                    }
                    else if (input[i + 1] == "fragments")
                    {
                        legendary["fragments"] += int.Parse(input[i]);

                        if (legendary["fragments"] >= 250)
                        {
                            legendary["fragments"] -= 250;
                            Console.WriteLine("Valanyr obtained!");
                            win = true;
                            break;
                        }
                    }
                    else if (input[i + 1] == "motes")
                    {
                        legendary["motes"] += int.Parse(input[i]);

                        if (legendary["motes"] >= 250)
                        {
                            legendary["motes"] -= 250;
                            Console.WriteLine("Dragonwrath obtained!");
                            win = true;
                            break;
                        }
                    }
                    else
                    {
                        if (junk.ContainsKey(input[i + 1]))
                        {
                            junk[input[i + 1]] += int.Parse(input[i]);
                        }
                        else
                        {
                            junk.Add(input[i + 1].ToLower(), int.Parse(input[i]));
                        }
                    }
                }

                if (win)
                {
                    break;
                }

                input1 = Console.ReadLine()
                .Split()
                .ToList();
            }

            legendary = legendary
              .OrderByDescending(x => x.Value)
              .ThenBy(x => x.Key)
              .ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in legendary)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            junk = junk.OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in junk)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
