using System;
using System.Text.RegularExpressions;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = @"^(.+)>([\d]{3})\|([a-z]{3})\|([A-Z]{3})\|([^<>]{3})<\1$";
            var numberOfInputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfInputs; i++)
            {
                var password = Console.ReadLine();
                if (Regex.IsMatch(password,regex))
                {
                    var groups = Regex.Match(password, regex).Groups;
                    Console.WriteLine($"Password: {groups[2].ToString() + groups[3].ToString() + groups[4].ToString() + groups[5].ToString()}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
