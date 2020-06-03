using System;
using System.Collections.Generic;
using System.Linq;

namespace Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            var orders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var max = GetBiggestOrder(orders);
            while (true)
            {
                if (orders.Count > 0)
                {
                    if (food >= orders.Peek())
                    {
                        food -= orders.Dequeue();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(max);
                        PrintOrders(orders);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(max);
                    Console.WriteLine($"Orders complete");
                    break;
                }
            }
        }
        static void PrintOrders(IEnumerable<int> collection) 
        {
            Console.Write("Orders left: ");
            foreach (var item in collection)
            {
                Console.Write(item + " ");
            }
        }
        static int GetBiggestOrder(IEnumerable<int> collection) 
        {
            var max = int.MinValue;
            foreach (var item in collection)
            {
                max = Math.Max(max,item);
            }
            return max;
        }
    }
}
