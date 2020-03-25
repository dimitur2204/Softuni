using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            var companies = new Dictionary<string, List<string>>();
            var command = Console.ReadLine();
            while (command != "End")
            {
                var tokens = command
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                var companyName = tokens[0];
                var ID = tokens[1];
                if (companies.ContainsKey(companyName))
                {
                    if (!companies[companyName].Contains(ID))
                    {
                        companies[companyName].Add(ID);
                    }
                }
                else
                {
                    companies.Add(companyName, new List<string> { ID });
                }
                command = Console.ReadLine();
            }
            companies = companies.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in companies)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var ID in item.Value)
                {
                    Console.WriteLine($"--{ID}");
                }
            }

        }
    }
}
