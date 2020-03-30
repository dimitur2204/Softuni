using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = @"@([A-Za-z]*)[^@\-!:>]*:(\d*)[^@\-!:>]*!([AD])[^@\-!:>]*![^@\-!:>]*->(\d*)";
            int numberOfMessages = int.Parse(Console.ReadLine());
            var attackedPlanets = new List<Planet>();
            var destroyedPlanets = new List<Planet>();
            for (int i = 0; i < numberOfMessages; i++)
            {
                StringBuilder message = new StringBuilder(Console.ReadLine());
                var decryptedMessage = DecryptMessage(message).ToString();
                if (Regex.IsMatch(decryptedMessage,regex))
                {
                    Match match = Regex.Match(decryptedMessage, regex);
                    var planetName = match.Groups[1].ToString();
                    var population = int.Parse(match.Groups[2].ToString());
                    var soldierCount = int.Parse(match.Groups[4].ToString());
                    var currentPlanet = new Planet(planetName,population,soldierCount);
                    if (match.Groups[3].ToString() == "A")
                    {
                        attackedPlanets.Add(currentPlanet);
                    }
                    else
                    {
                        destroyedPlanets.Add(currentPlanet);
                    }
                }
            }
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            attackedPlanets = attackedPlanets
                .OrderBy(x => x.Name)
                .ToList();
            PlanetInfo(attackedPlanets);
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            destroyedPlanets = destroyedPlanets
                .OrderBy(x => x.Name)
                .ToList();
            PlanetInfo(destroyedPlanets);

            //Attacked planets: 1
            //->Alderaa
            //Destroyed planets: 1
            //->Cantonica

        }
        public static void PlanetInfo(List<Planet> planets) 
        {
            foreach (var planet in planets)
            {
                Console.WriteLine($"-> {planet.Name}");
            }
        }
        public static StringBuilder DecryptMessage(StringBuilder message) 
        {
            var count = CountOfSTAR(message);
            for (int i = 0; i < message.Length; i++)
            {
                message[i] -= (char)count;
            }
            return message;
        }
        public static int CountOfSTAR(StringBuilder message)
        {
            var counter = 0;
            foreach (var symbol in message.ToString())
            {
                var letter = symbol.ToString().ToLower();
                
                if (letter == "s" || letter == "t" || letter == "a" || letter == "r")
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
