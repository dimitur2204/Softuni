using System;
using System.Collections.Generic;

namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");
            List<string> validUsernames = new List<string>();
            foreach (var username in usernames)
            {
                bool isValid = true;
                if (username.Length < 3 || username.Length > 16 )
                {
                    continue;
                }
                foreach (var symbol in username)
                {
                    if (!(char.IsLetterOrDigit(symbol) || symbol == '-' || symbol == '_'))
                    {
                        isValid = false;
                    }
                }
                if (isValid)
                {
                    validUsernames.Add(username);
                }
            }
            Console.WriteLine(String.Join("\n", validUsernames));
        }
    }
}
