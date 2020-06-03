using System;
using System.Collections;
using System.Linq;

namespace Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x));
            var queue = new Queue();
            foreach (var number in input)
            {
                if (number % 2 == 0)
                {
                    queue.Enqueue(number);
                }
            }
            while (queue.Count > 0)
            {
                if (queue.Count == 1)
                {
                    Console.Write(queue.Dequeue());
                    break;
                }
                Console.Write(queue.Dequeue() + ", ");
            }
        }
    }
}
