using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            var bombEffects = new Queue<int>(Console.ReadLine().Split( ", ",
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            var bombCasings = new Stack<int>(Console.ReadLine().Split(", ",
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            var bombPouch = new Dictionary<string, int>()
            {
                {"Datura Bombs", 0},
                {"Cherry Bombs", 0},
                {"Smoke Decoy Bombs", 0},
            };
            while (true)
            {
                if (bombPouch.All(x => x.Value >= 3))
                {
                    Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
                    break;
                }

                if (!bombCasings.Any() || !bombEffects.Any())
                {
                    Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
                    break;
                }

                var bombEff = bombEffects.Peek();
                var bombCas = bombCasings.Peek();
                var sum = bombEff + bombCas;
                if (sum == 40)
                {
                    bombPouch["Datura Bombs"]++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else if (sum == 60)
                {
                    bombPouch["Cherry Bombs"]++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else if (sum == 120)
                {
                    bombPouch["Smoke Decoy Bombs"]++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else
                {
                    bombCasings.Push(bombCasings.Pop() - 5);
                }
            }

            if (bombEffects.Any())
            {
                Console.WriteLine($"Bomb Effects: {String.Join(", ",bombEffects)}");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: empty");
            }
            if (bombCasings.Any())
            {
                Console.WriteLine($"Bomb Casings: {String.Join(", ", bombCasings)}");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: empty");
            }

            foreach (var bomb in bombPouch.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}
