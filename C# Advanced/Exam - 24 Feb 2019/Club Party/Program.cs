using System;
using System.Collections.Generic;
using System.Linq;

namespace Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxCap = long.Parse(Console.ReadLine());
            var input = new Stack<string>(Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries));
            var halls = new Dictionary<char, List<long>>();
            while (input.Any())
            {
                var element = input.Pop();
                if (Char.TryParse(element,out char hall1) && Char.IsLetter(hall1))
                {
                    if (!halls.ContainsKey(hall1))
                    {
                        halls.Add(hall1, new List<long>());
                    }
                }
                else
                {
                    var reservation = long.Parse(element);
                    if (halls.Any())
                    {
                        foreach (var (hall, value) in halls)
                        {
                            if (value.Sum() + reservation <= maxCap)
                            {
                                halls[hall].Add(reservation);
                                break;
                            }

                            PrintHall(hall,value);
                            halls.Remove(hall);
                        }
                    }
                }
            }
        }

        static void PrintHall(char hall, List<long> reservations)
        {
            //a -> 20, 20, 20
            if (reservations.Any())
            {
                Console.WriteLine(hall + " -> " + String.Join(", ", reservations));
            }
        }
    }
}
