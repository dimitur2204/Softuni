using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemonDistances = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToList();
            int sumOfPokmemons = 0;

            while (pokemonDistances.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());
                if (index < 0)
                {
                    int distanceWhenLess = pokemonDistances[0];
                    pokemonDistances[0] = pokemonDistances[pokemonDistances.Count - 1];
                    sumOfPokmemons += distanceWhenLess;
                    pokemonDistances = IncreaseAndDecrease(distanceWhenLess, pokemonDistances);
                }
                else if (index >= pokemonDistances.Count)
                {
                    int distanceWhenMore = pokemonDistances[pokemonDistances.Count - 1];
                    pokemonDistances[pokemonDistances.Count - 1] = pokemonDistances[0];
                    sumOfPokmemons += distanceWhenMore;
                    pokemonDistances = IncreaseAndDecrease(distanceWhenMore, pokemonDistances);
                }
                else
                {
                    int distance = pokemonDistances[index];
                    sumOfPokmemons += pokemonDistances[index];
                    pokemonDistances.RemoveAt(index);
                    IncreaseAndDecrease(distance, pokemonDistances);
                }               
            }
            Console.WriteLine(sumOfPokmemons);
        }
        private static List<int> IncreaseAndDecrease(int value, List<int> distances)
        {
            for (int i = 0; i < distances.Count; i++)
            {
                if (distances[i] <= value)
                {
                    distances[i] += value;
                }
                else
                {
                    distances[i] -= value;
                }
            }
            return distances;
        }

    }
}




