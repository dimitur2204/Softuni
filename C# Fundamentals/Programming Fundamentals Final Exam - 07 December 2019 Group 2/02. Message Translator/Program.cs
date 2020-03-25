using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Message_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfInputs = int.Parse(Console.ReadLine());
            var regex = @"\!([A-Z][a-z]*)\!\:\[([A-Za-z]{8,})\]";            
            for (int i = 0; i < numberOfInputs; i++)
            {
                var input = Console.ReadLine();
                var encrypted = new List<int>();
                if (Regex.IsMatch(input,regex))
                {
                    Match match = Regex
                        .Match(input, regex);
                    var message =
                        match
                        .Groups[2]
                        .ToString();
                    foreach (var symbol in message)
                    {
                        encrypted.Add(symbol);
                    }
                    Console.WriteLine($"{match.Groups[1].ToString()}: {String.Join(" ",encrypted)}");
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                    continue;
                }
            }
        }
    }
}
