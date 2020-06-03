using System;
using System.Collections.Generic;
using System.Linq;

namespace Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
           var entries = int.Parse(Console.ReadLine());
           var pumps = new Queue<int[]>();

            for (int entry = 0; entry < entries; entry++)
                pumps.Enqueue(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());

            for (int entry = 0; entry < entries; entry++)
            {
                if (IsSolution(pumps,entries))
                {
                    Console.WriteLine(entry);
                    break;
                }
                pumps.Enqueue(pumps.Dequeue());
            }

        }

        static bool IsSolution(Queue<int[]> pumps, int entries)
        {
            int tankFuel = 0;
            bool foundAnswer = true;

            for (int entry = 0; entry < entries; entry++)
            {
                int[] currPump = pumps.Dequeue();
                tankFuel += currPump[0] - currPump[1];
                if (tankFuel < 0)
                    foundAnswer = false;
                pumps.Enqueue(currPump);
            }

            return foundAnswer;
        }
    }
}
