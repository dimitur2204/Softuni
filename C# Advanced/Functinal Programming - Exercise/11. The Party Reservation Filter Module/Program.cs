using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine().Split().ToList();
            var initialCommand = Console.ReadLine();
            Func<string,string,bool> startsWith = (s,c) => s.StartsWith(c);
            Func<string, string, bool> endsWith = (s, c) => s.EndsWith(c);
            Func<string, string, bool> hasLength = (s, l) => s.Length == int.Parse(l);
            Func<string, string, bool> contains = (s, c) => s.Contains(c);
            List<Func<string, string, bool>> filters = new List<Func<string, string, bool>>();
            while (initialCommand != "Print")
            {
                var tokens = initialCommand.Split(';', StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0].Split()[0];
                var filter = tokens[1];
                var argument = tokens[2];
                if (command == "Add")
                {
                    if (filter == "Starts with")
                    {
                        filters.Add(startsWith);
                    }
                    else if (filter == "Ends with")
                    {
                        filters.Add(endsWith);
                    }
                    else if (filter == "Length")
                    {
                        filters.Add(hasLength);
                    }
                    else if (filter == "Contains")
                    {
                        filters.Add(contains);
                    }
                }
                else
                {
                    if (filter == "Starts with")
                    {
                        filters.Remove(startsWith);
                    }
                    else if (filter == "Ends with")
                    {
                        filters.Remove(endsWith);
                    }
                    else if (filter == "Length")
                    {
                        filters.Remove(hasLength);
                    }
                    else if (filter == "Contains")
                    {
                        filters.Remove(contains);
                    }
                }
            }
        }
    }
}
