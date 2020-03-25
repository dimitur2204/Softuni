using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Hero_Recruitment
{
    class Program
    {
        static void Main(string[] args)
        {
            var heroes = new Dictionary<string,List<string>>();
            var command = Console.ReadLine();
            while (command != "End")
            {
                var tokens = command.Split();
                if (tokens[0] == "Enroll")
                {
                    var heroName = tokens[1];
                    if (DoesHeroExist(heroes, heroName))
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        heroes.Add(heroName, new List<string>());
                    }
                }
                else if (tokens[0] == "Learn")
                {
                    var heroName = tokens[1];
                    var spellName = tokens[2];
                    if (!DoesHeroExist(heroes, heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                        command = Console.ReadLine();
                        continue;
                    }
                    else if (DoesSpellExist(heroes , heroName, spellName))
                    {
                        Console.WriteLine($"{heroName} has already learnt {spellName}.");
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        heroes[heroName].Add(spellName);
                    }
                }
                else if (tokens[0] == "Unlearn")
                {
                    var heroName = tokens[1];
                    var spellName = tokens[2];
                    if (!DoesHeroExist(heroes, heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                        command = Console.ReadLine();
                        continue;
                    }
                    else if (!DoesSpellExist(heroes, heroName, spellName))
                    {
                        Console.WriteLine($"{heroName} doesn't know {spellName}.");
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        heroes[heroName].Remove(spellName);
                    }
                }
                command = Console.ReadLine();
            }
            heroes = heroes
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("Heroes:");
            foreach (var hero in heroes)
            {
                Console.WriteLine($"== {hero.Key}: {String.Join(", ", hero.Value)}");
            }
        }
        static bool DoesHeroExist(Dictionary<string, List<string>> heroes, string hero) 
        {
            if (heroes.ContainsKey(hero))
            {
                return true;
            }
            return false;
        }
        static bool DoesSpellExist(Dictionary<string, List<string>> heroes, string hero, string spell)
        {
            if (heroes[hero].Contains(spell))
            {
                return true;
            }
            return false;
        }
    }
}
