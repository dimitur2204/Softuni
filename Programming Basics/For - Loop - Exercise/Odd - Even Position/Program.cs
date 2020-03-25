using System;

namespace Odd___Even_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNumbers = int.Parse(Console.ReadLine());
            double evenSum = 0.0;
            double evenMax = double.MinValue;
            double evenMin = double.MaxValue;
            double oddSum = 0.0;
            double oddMax = double.MinValue;
            double oddMin = double.MaxValue;
           
            for (int i = 1; i <= numberOfNumbers; i++)
            {
                double inputNumber = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenSum += inputNumber;

                    if (evenMax < inputNumber)
                    {
                        evenMax = inputNumber;
                    }

                    if (evenMin > inputNumber)
                    {
                        evenMin = inputNumber;
                    }

                }

                else
                {
                    oddSum += inputNumber;

                    if (oddMax < inputNumber)
                    {
                        oddMax = inputNumber;
                    }

                    if (oddMin > inputNumber)
                    {
                        oddMin = inputNumber;
                    }

                }
            }

            Console.WriteLine($"OddSum={oddSum:f2},");

            if (oddMin == double.MaxValue)
            {
                Console.WriteLine("OddMin=No,");
            }
            else
            {
                Console.WriteLine($"OddMin={oddMin:f2},");
            }

            if (oddMax == double.MinValue)
            {
                Console.WriteLine("OddMax=No,");
            }
            else
            {
                Console.WriteLine($"OddMax={oddMax:f2},");
            }

            Console.WriteLine($"EvenSum={evenSum:f2},");

            if (evenMin == double.MaxValue)
            {
                Console.WriteLine("EvenMin=No,");
            }
            else
            {
                Console.WriteLine($"EvenMin={evenMin:f2},");
            }

            if (evenMax == double.MinValue)
            {
                Console.WriteLine("EvenMax=No");
            }
            else
            {
                Console.WriteLine($"EvenMax={evenMax:f2}");
            }
        }
    }
}
