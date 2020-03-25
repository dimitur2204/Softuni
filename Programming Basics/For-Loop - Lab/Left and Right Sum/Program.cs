using System;

namespace Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNumbers = int.Parse(Console.ReadLine());
            int sumOfLeftSide = 0;

            for (int i = 0; i < numberOfNumbers; i++)
            {
                int inputNumberLeft = int.Parse(Console.ReadLine());
                sumOfLeftSide += inputNumberLeft;
            }

            int sumOfRightSide = 0;
            for (int i = numberOfNumbers - 1; i >= 0; i--)
            {
                int inputNumberRight = int.Parse(Console.ReadLine());
                sumOfRightSide += inputNumberRight;
            }

            int difference = Math.Abs(sumOfRightSide - sumOfLeftSide);

            if (difference == 0)
            {
                Console.WriteLine($"Yes, sum = {sumOfLeftSide}");
            }
            else
            {
                Console.WriteLine($"No, diff = {difference}");
            }
        }
    }
}
