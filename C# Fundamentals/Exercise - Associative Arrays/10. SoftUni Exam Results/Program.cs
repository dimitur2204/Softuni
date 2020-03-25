using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new Dictionary<string, int>();
            var languages = new Dictionary<string, int>();
            var command = Console.ReadLine();
            while (command != "exam finished")
            {

                var tokens = command.Split("-");
                if (tokens[1] == "banned")
                {
                    var name = tokens[0];
                    users.Remove(name);
                }
                else
                {
                    var username = tokens[0];
                    var language = tokens[1];
                    var points = int.Parse(tokens[2]);

                    if (languages.ContainsKey(language))
                    {
                        languages[language]++;
                    }
                    else
                    {
                        languages.Add(language, 1);
                    }

                    if (users.ContainsKey(username))
                    {
                        if (users[username] < points)
                        {
                            users[username] = points;
                        }                      
                    }
                    else
                    {
                        users.Add(username, points);
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("Results:");
            users = users
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }
            Console.WriteLine("Submissions:");
            languages = languages
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var language in languages)
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
