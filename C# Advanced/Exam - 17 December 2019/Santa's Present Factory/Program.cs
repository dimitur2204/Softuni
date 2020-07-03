using System;
using System.Collections.Generic;
using System.Linq;

namespace Santa_s_Present_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var materials = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var magic = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var toys = new Dictionary<string,int>();
            while (true)
            {
                if (!materials.Any() || !magic.Any())
                {
                    break;
                }

                var lastBox = materials.Peek();
                var firstMagic = magic.Peek();
                var result = lastBox * firstMagic;
                if (result == 150)
                {
                    AddToy(toys,"Doll");
                    materials.Pop();
                    magic.Dequeue();
                }
                else if (result == 250)
                {
                    AddToy(toys, "Wooden train");
                    materials.Pop();
                    magic.Dequeue();
                }
                else if (result == 300)
                {
                    AddToy(toys, "Teddy bear");
                    materials.Pop();
                    magic.Dequeue();
                }
                else if (result == 400)
                {
                    AddToy(toys, "Bicycle");
                    materials.Pop();
                    magic.Dequeue();
                }
                else
                {
                    if (result < 0)
                    {
                        result = firstMagic + lastBox;
                        materials.Pop();
                        magic.Dequeue();
                        materials.Push(result);
                    }   
                    else if (result > 0)
                    {
                        magic.Dequeue();
                        materials.Push(materials.Pop() + 15);
                    }
                    else
                    {
                        if (firstMagic == 0)
                        {
                            magic.Dequeue();
                        }

                        if (lastBox == 0)
                        {
                            materials.Pop();
                        }
                    }
                }
            }
            if (toys.ContainsKey("Doll") && toys.ContainsKey("Wooden train")
                || toys.ContainsKey("Teddy bear") && toys.ContainsKey("Bicycle"))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }
            if (materials.Any())
            {
                Console.Write($"Materials left: {String.Join(", ",materials)}");
                Console.WriteLine();
            }
            if (magic.Any())
            {
                Console.Write($"Materials left: {String.Join(", ", magic)}");
                Console.WriteLine();
            }

            foreach (var toy in toys.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{toy.Key}: {toy.Value}");
            }
        }

        private static void AddToy(Dictionary<string,int> toys,string toy)
        {
            if (!toys.ContainsKey(toy))
            {
                toys.Add(toy, 0);
            }

            toys[toy]++;
        }
    }
}
