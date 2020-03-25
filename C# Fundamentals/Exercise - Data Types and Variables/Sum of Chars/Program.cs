using System;

namespace Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfChars = int.Parse(Console.ReadLine());
            int sumOfAciiCodes = 0;
            for (int charNumber = 0; charNumber < numberOfChars; charNumber++)
            {
                char currentChar = char.Parse(Console.ReadLine());
                sumOfAciiCodes += (int)(currentChar);
            }
            Console.WriteLine($"The sum equals: {sumOfAciiCodes}");
        }
    }
}
