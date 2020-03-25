using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var buyers = new List<IBuyer>();
            var numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                var tokens = Console.ReadLine().Split();
                if (tokens.Length > 3)
                {
                    var citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]);
                    buyers.Add(citizen);
                }
                else
                {
                    var rebel = new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    buyers.Add(rebel);
                }               
            }
            var command = Console.ReadLine();
            while (command!="End")
            {
                var name = command;
                if (buyers
                    .Where(x => x.Name == name)
                    .ToList().Count == 1)
                {
                    buyers
                    .Where(x => x.Name == name)
                    .ToList()[0]
                    .BuyFood();
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(buyers.Sum(x => x.Food));
        }
    }
}
