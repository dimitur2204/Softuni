using System;
using System.Collections.Generic;
using System.Linq;

namespace Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var wastedWater = 0;
            while (true)
            {
                if (cups.Count == 0)
                {
                    Console.Write($"Bottles: ");
                    while (bottles.Count > 0)
                    {
                        Console.Write(bottles.Pop() + " ");
                    }
                    Console.WriteLine();
                    Console.WriteLine($"Wasted litters of water: {wastedWater}");
                    return;
                }
                if (bottles.Count == 0)
                {
                    Console.Write("Cups: ");
                    while (cups.Count > 0)
                    {
                        Console.Write(cups.Dequeue() + " ");
                    }
                    Console.WriteLine();
                    Console.WriteLine($"Wasted litters of water: {wastedWater}");
                    return;
                }
                var bottle = bottles.Pop();
                var cup = cups.Peek();
                if (bottle >= cup)
                {
                    cups.Dequeue();
                    bottle -= cup;
                    wastedWater += bottle;
                }
                else
                {
                    cup -= bottle;
                    while (cup > 0 && bottles.Any())
                    {
                        var currentBottle = bottles.Pop();
                        if (currentBottle >= cup)
                        {
                            cups.Dequeue();
                            currentBottle -= cup;
                            wastedWater += currentBottle;
                            break;
                        }
                        else
                        {
                            cup -= currentBottle;
                            continue;
                        }
                    }
                }
            }
        }
    }
}
