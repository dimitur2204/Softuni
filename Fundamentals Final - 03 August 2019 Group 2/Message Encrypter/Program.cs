using System;
using System.Text.RegularExpressions;

namespace Message_Encrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = @"([\*\@])([A-Z][a-z]{2,})\1: \[([A-Za-z])\]\|\[([A-Za-z])\]\|\[([A-Za-z])\]\|$";
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var message = Console.ReadLine();
                if (Regex.IsMatch(message, regex))
                {
                    Match match = Regex.Match(message, regex);
                    Console.WriteLine($"{match.Groups[2]}: {(int)match.Groups[3].ToString().ToCharArray()[0]} {(int)match.Groups[4].ToString().ToCharArray()[0]} {(int)match.Groups[5].ToString().ToCharArray()[0]}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
