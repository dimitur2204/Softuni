using System;

namespace Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int initialNumber = number;
            int sum = 0;
            while (number != 0)
            {
                int lastDigit = number % 10;
                int factOfDigit = 1;
                for (int i = 1; i <= lastDigit; i++)
                {
                    factOfDigit = factOfDigit * i;
                }
                sum = sum + factOfDigit;
                number = number / 10;
            }
            if (sum == initialNumber)
            {
                Console.WriteLine("yes"); 
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
