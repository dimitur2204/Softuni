using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            //Part One Interview: success
            // Js Fundamentals: Pesho
            //  C# Fundamentals:fundPass
            //Algorithms: fun
            // end of contests
            var contests = new Dictionary<string, string>();
            InitializeContests(contests);
            var users = new Dictionary<string,Dictionary<string,int>>();
            var submission = Console.ReadLine();
            while (submission != "end of submissions")
            {
                var tokens = submission.Split("=>");
                var contest = tokens[0];
                var passGiven = tokens[1];
                var user = tokens[2];
                var points = int.Parse(tokens[3]);
                if (contests.ContainsKey(contest) && contests[contest] == passGiven)
                {
                    if (!users.ContainsKey(user))
                    {
                        users.Add(user, new Dictionary<string, int>());
                    }
                    if (!users[user].ContainsKey(contest))
                    {
                        users[user].Add(contest,points);
                    }
                    else
                    {
                        if (points > users[user][contest])
                        {
                            users[user][contest] = points;
                        }
                    }
                }
                submission = Console.ReadLine();
            }
            var bestUser = users.OrderByDescending(x => x.Value.Values.Sum()).ToArray()[0];
            Console.WriteLine($"Best candidate is {bestUser.Key} with total {bestUser.Value.Values.Sum()} points.");
            Console.WriteLine("Ranking:");
            foreach (var (name,courses) in users.OrderBy(x => x.Key))
            {
                // Nikola
                //#  C# Fundamentals -> 200
                //#  Part One Interview -> 120
                Console.WriteLine(name);
                foreach (var course in courses.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine("#  " + course.Key + " -> " + course.Value);
                }
            }
        }

        private static void InitializeContests(Dictionary<string, string> contests)
        {
            var contestAndPass = Console.ReadLine();
            while (contestAndPass != "end of contests")
            {
                var contest = contestAndPass.Split(":")[0];
                var pass = contestAndPass.Split(":")[1];
                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, pass);
                }
                contestAndPass = Console.ReadLine();
            }
        }
    }
}
