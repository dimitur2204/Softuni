using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            GetLowest(num1, num2, num3);
        }

        private static void GetLowest(int num1, int num2, int num3)
        {
            int lowest = int.MinValue;
            if (num1 > num2)
            {
                lowest = num2;
            }
            else
            {
                lowest = num1;
            }

            if (lowest > num3)
            {
                lowest = num3;
            }
            Console.WriteLine(lowest);
        }
    }
}
