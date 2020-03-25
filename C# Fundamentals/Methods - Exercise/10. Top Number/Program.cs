using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                if (IsTop(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool IsTop(int number) 
        {
            bool isTop = true;
            bool onlyEvenDig = true;
            int sumOfDigits = 0;
            while (number != 0)
            {
                
                sumOfDigits += number % 10;
                if ((number % 10) % 2 != 0)
                {
                    onlyEvenDig = false;
                }
                number /= 10;
            }
            if (sumOfDigits % 8 != 0 || onlyEvenDig)
            {
                isTop = false;
            }
            return isTop;
        }
    }
}
