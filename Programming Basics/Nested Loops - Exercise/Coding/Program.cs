using System;

namespace Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string numberInString = number.ToString();
            for (int rows = 0; rows < numberInString.Length; rows++)
            {                              
                if (number % 10 == 0)
                {
                    Console.WriteLine("ZERO");
                }
                else
                {
                    for (int i = 0; i < number % 10; i++)
                    {
                        int element = (number % 10) + 33;
                        Console.Write($"{(char)(element)}");
                    }
                    Console.WriteLine();
                }
                number = number / 10;
            }
        }
    }
}
