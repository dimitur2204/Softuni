using System;

namespace Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputCommand = Console.ReadLine();
            int primeSum = 0;
            int nonPrimeSum = 0;
            while(inputCommand != "stop") 
            {
                int inputNumber = int.Parse(inputCommand);
                
                if (inputNumber < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else
                {
                    bool isPrime = true;
                    if (inputNumber == 1 || inputNumber == 0)
                    {
                        isPrime = false;
                    }
                    else
                    {
                        for (int i = 2; i < inputNumber ; i++)
                        {
                            if (inputNumber % i == 0)
                            {
                                isPrime = false;
                            }
                        }
                    }
                    if (isPrime == true)
                    {
                        primeSum += inputNumber;
                    }
                    else
                    {
                        nonPrimeSum += inputNumber;
                    }
                }
                inputCommand = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }
    }
}
