using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToList();
            var command = Console.ReadLine();
            Func<string, string, bool> startsWith = (s, c) =>
            {
                if (s.StartsWith(c))
                {
                    return true;
                }
                return false;
            };
            Func<string, string, bool> endsWith = (s, c) =>
            {
                if (s.EndsWith(c))
                {
                    return true;
                }
                return false;
            };
            Func<string, int, bool> hasLength = (s, l) =>
            {
            if (s.Length == l)
                {
                    return true;
                }
                return false;
            };
            Action<List<string>, Func<string, string, bool>,string> clone = (l, func, c) =>
            {
                for (int i = 0; i < l.Count; i++)
                {
                    if (func(l[i],c))
                    {
                        l.Insert(i,l[i]);
                        i++;
                    }
                }
            };
            Action<List<string>, Func<string, int, bool>, int> cloneLength = (l, func, c) =>
            {
                for (int i = 0; i < l.Count; i++)
                {
                    if (func(l[i], c))
                    {
                        l.Insert(i, l[i]);
                        i++;
                    }
                }
            };
            Action<List<string>, Func<string, string, bool>, string> remove = (l, func, c) =>
            {
                for (int i = 0; i < l.Count; i++)
                {
                    if (func(l[i], c))
                    {
                        l.RemoveAt(i);
                        i--;
                    }
                }
            };
            Action<List<string>, Func<string, int, bool>, int> removeLength = (l, func, c) =>
            {
                for (int i = 0; i < l.Count; i++)
                {
                    if (func(l[i], c))
                    {
                        l.RemoveAt(i);
                        i--;
                    }
                }
            };
            while (command != "Party!")
            {
                var tokens = command.Split();
                var action = tokens[0];
                var predicate = tokens[1];
                if (action == "Double")
                {
                    if (predicate == "StartsWith")
                    {
                        var symbol = tokens[2];
                        clone(people,startsWith,symbol);
                    }
                    else if (predicate == "EndsWith")
                    {
                        var symbol = tokens[2];
                        clone(people, endsWith, symbol);
                    }
                    else
                    {
                        var length = int.Parse(tokens[2]);
                        cloneLength(people, hasLength, length);
                    }
                }
                else if (action == "Remove")
                {
                    if (predicate == "StartsWith")
                    {
                        var symbol = tokens[2];
                        remove(people, startsWith, symbol);
                    }
                    else if (predicate == "EndsWith")
                    {
                        var symbol = tokens[2];
                        remove(people, endsWith, symbol);
                    }
                    else
                    {
                        var length = int.Parse(tokens[2]);
                        removeLength(people, hasLength, length);
                    }
                }
                command = Console.ReadLine();
            }
            if (people.Count > 0)
            {
                Console.WriteLine(string.Join(", ",people) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
