using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            Console.WriteLine($"{GetFactoriel(num1) / GetFactoriel(num2):f2}");
        }

        static double GetFactoriel(double num) 
        {
            double fact = 1;
            for (double i = 1; i <= num; i++)
            {
                fact *= i;
            }
            return fact;
        }
    }
}
