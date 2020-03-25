using System;

namespace Multiplication_Table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int multiplier = int.Parse(Console.ReadLine());
            int times = int.Parse(Console.ReadLine());
            if (times <= 10)
            {
                for (int i = times; i <= 10; i++)
                {
                    Console.WriteLine($"{multiplier} X {i} = {multiplier * i}");
                }
            }
            else
            {
                Console.WriteLine($"{multiplier} X {times} = {multiplier * times}");
            }
        }
    }
}
