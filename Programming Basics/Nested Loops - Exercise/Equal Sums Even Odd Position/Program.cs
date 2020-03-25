using System;

namespace Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstInterval = int.Parse(Console.ReadLine());
            int secondInterval = int.Parse(Console.ReadLine());
            for (int number = firstInterval; number <= secondInterval; number++)
            {
                int firstDigit = number % 10;
                int secondDigit = number / 10 % 10;
                int thirdDigit = number / 100 % 10;
                int fourthDigit = number / 1000 % 10;
                int fifthDigit = number / 10000 % 10;
                int sixthDigit = number / 100000 % 10;
                if ((firstDigit + thirdDigit + fifthDigit) == (secondDigit + fourthDigit + sixthDigit))
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
