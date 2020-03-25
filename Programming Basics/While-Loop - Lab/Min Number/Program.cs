using System;

namespace Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            int minNumber = int.MaxValue;
            int input;
            while (numberOfInputs != 0)
            {
                input = int.Parse(Console.ReadLine());
                numberOfInputs--;
                if (input < minNumber)
                {
                    minNumber = input;
                }


            }
            Console.WriteLine(minNumber);
        }
    }
}
