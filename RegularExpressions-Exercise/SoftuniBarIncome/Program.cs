using System;
using System.Text.RegularExpressions;

namespace SoftuniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = @"^%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?\d+([eE][-+]?\d+)?)\$";
            var command = Console.ReadLine();
            var totalIncome = 0.0;
            while (command != "end of shift")
            {
                if (Regex.IsMatch(command,regex))
                {
                    Match match = Regex.Match(command,regex);
                    var customerName = match.Groups[2].ToString();
                    var productName = match.Groups[3].ToString();
                    var quantity = int.Parse(match.Groups[4].ToString());
                    var price = double.Parse(match.Groups[5].ToString());
                    Console.WriteLine($"{customerName}: {productName} - {(quantity * price):f2}");
                    totalIncome += quantity * price;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
