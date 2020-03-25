using System;
using System.Text.RegularExpressions;

namespace RegularExpressions_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b[A-Z][a-z]+ \b[A-Z][a-z]+\b";
            string names = Console.ReadLine();
            MatchCollection matches = Regex.Matches(names, pattern);
            foreach (Match match in matches)
            {
                Console.Write(match.Value + " ");
            }
            Console.WriteLine();
        }
    }
}
