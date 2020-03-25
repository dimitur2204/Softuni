using System;

namespace Town_Info
{
    class Program
    {
        static void Main(string[] args)
        {
            string townName = Console.ReadLine();
            UInt64 population = UInt64.Parse(Console.ReadLine());
            UInt64 area = UInt64.Parse(Console.ReadLine());
            Console.WriteLine($"Town {townName} has population of {population} and area {area} square km.");
        }
    }
}
