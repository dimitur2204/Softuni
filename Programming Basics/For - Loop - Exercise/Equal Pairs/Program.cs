using System;

namespace Equal_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNumbers = int.Parse(Console.ReadLine());            
            int maxDifference = int.MinValue;
            int sumOfPair = 0;
            for (int i = 0; i < numberOfNumbers ; i++)
            {
                
                int firstNumber = int.Parse(Console.ReadLine());
                int secondNumber = int.Parse(Console.ReadLine());
                int currentSum = 0;
                if (i == 0)
                {
                    currentSum =  firstNumber + secondNumber;
                }
                else
                {
                    currentSum = firstNumber + secondNumber;
                }
            }
            ""
        }
    }
}
