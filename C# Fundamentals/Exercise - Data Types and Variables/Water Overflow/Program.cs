using System;

namespace Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPourings = int.Parse(Console.ReadLine());
            int sumOfPourings = 0;
            for (int i = 0; i < numberOfPourings; i++)
            {
                int currentPouring = int.Parse(Console.ReadLine());
                sumOfPourings += currentPouring;
                if (sumOfPourings > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    sumOfPourings -= currentPouring;
                }
            }
            Console.WriteLine($"{sumOfPourings}");
        }
    }
}
