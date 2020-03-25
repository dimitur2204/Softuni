using System;

namespace Multiply_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int thirdDigit = number % 10;
            int secondDigit = number / 10 % 10;
            int firstDigit = number / 100 % 10;
                for (int i = 1; i <= thirdDigit; i++)
                {
                    for (int j = 1; j <= secondDigit; j++)
                    {
                        for (int k = 1; k <= firstDigit; k++)
                        {
                        int multiplication = i * j * k;
                        Console.WriteLine(i + " * " + j + " * " + k + " = " + multiplication + ";");
                        }
                    }
                }
        }
    }
}
