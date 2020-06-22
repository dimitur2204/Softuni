using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstBox = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var secondBox = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var collection = 0;

            while (true)
            {
                if (!firstBox.Any())
                {
                    Console.WriteLine("First lootbox is empty");
                    break;
                }

                if (!secondBox.Any())
                {
                    Console.WriteLine("Second lootbox is empty");
                    break;
                }

                var firstBoxItem = firstBox.Peek();
                var secondBoxItem = secondBox.Peek();
                var sum = firstBoxItem + secondBoxItem;
                if (sum % 2 == 0)
                {
                    collection += sum;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }

            if (collection >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {collection}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {collection}");
            }
        }
    }
}
