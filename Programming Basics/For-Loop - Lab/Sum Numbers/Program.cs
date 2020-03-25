using System;

namespace Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNumbers = int.Parse(Console.ReadLine());
            int sumOfNumbers = 0;
            for (int i = 0; i < numberOfNumbers; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());
                sumOfNumbers += inputNumber;
            }
            Console.WriteLine(sumOfNumbers);
        }
    }
}
