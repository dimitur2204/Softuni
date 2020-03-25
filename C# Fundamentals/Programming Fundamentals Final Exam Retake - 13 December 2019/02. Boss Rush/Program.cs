using System;
using System.Text.RegularExpressions;

namespace _02._Boss_Rush
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = @"\|([A-Z]*)\|\:\#([A-Za-z]* [A-Za-z]*)\#";
            var numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                var bossInfo = Console.ReadLine();
                if (Regex.IsMatch(bossInfo, regex))
                {
                    Match match = Regex.Match(bossInfo, regex);
                    var bossName = match.Groups[1].ToString();
                    var bossTitle = match.Groups[2].ToString();
                    Console.WriteLine($"{bossName}, The {bossTitle}\n>> Strength: {bossName.Length}\n>> Armour: {bossTitle.Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                    continue;
                }
            }
        }
    }
}
