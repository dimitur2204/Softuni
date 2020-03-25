using System;

namespace Exact_Sum_of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNumbers = int.Parse(Console.ReadLine());
            decimal sumOfNumbers = 0;
            for (int i = 0; i < numberOfNumbers; i++)
            {
                decimal newNumber = decimal.Parse(Console.ReadLine());
                sumOfNumbers += newNumber;
            }
            Console.WriteLine(sumOfNumbers);
        }
    }
}
