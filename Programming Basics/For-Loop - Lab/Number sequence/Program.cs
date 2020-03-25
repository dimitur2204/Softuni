using System;

namespace Number_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNumbers = int.Parse(Console.ReadLine());
            int maxNumber = int.MinValue;
            int minNumber = int.MaxValue;
            for (int i = 0; i < numberOfNumbers; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());
                
                if(inputNumber > maxNumber) 
                {
                    maxNumber = inputNumber;
                }
                if (inputNumber < minNumber)
                {
                    minNumber = inputNumber;
                }
            }
            Console.WriteLine($"Max number: {maxNumber}");
            Console.WriteLine($"Min number: {minNumber}");
        }
    }
}
