using System;
using System.Collections;
using System.Linq;

namespace Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            int toss = int.Parse(Console.ReadLine());
            var queue = new Queue(input);

            while (queue.Count > 1)
            {
                for (int i = 1; i < toss; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}

