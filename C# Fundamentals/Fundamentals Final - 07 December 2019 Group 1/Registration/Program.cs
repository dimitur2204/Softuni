using System;
using System.Text.RegularExpressions;

namespace Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = @"U\$([A-Z][a-z]{2,})U\$P\@\$([A-Za-z]{5,}\d+)P\@\$";
            var numberOfLines = int.Parse(Console.ReadLine());
            var numberOfRegistrations = 0;
            for (int i = 0; i < numberOfLines; i++)
            {
                var username = Console.ReadLine();
                if (Regex.IsMatch(username,regex))
                {
                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {Regex.Match(username,regex).Groups[1]}, Password: {Regex.Match(username, regex).Groups[2]}");
                    numberOfRegistrations++;
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }
            Console.WriteLine($"Successful registrations: {numberOfRegistrations}");
        }
    }
}
