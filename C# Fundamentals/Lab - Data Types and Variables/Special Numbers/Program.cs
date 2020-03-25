using System;

namespace Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int interval = int.Parse(Console.ReadLine());
            for (int i = 1; i <= interval; i++)
            {
                int sumOfDigits = 0;
                int number = i;
                while (number > 0)
                {
                    sumOfDigits += number % 10;
                    number /= 10;
                }
                bool isSpecial = false;
                if (sumOfDigits == 5 || sumOfDigits == 7 || sumOfDigits == 11)
                {
                    isSpecial = true;
                }
                Console.WriteLine($"{i} -> {isSpecial}");
            }
        }
    }
}
