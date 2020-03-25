using System;

namespace LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;
            foreach (var number in numbers)
            {
                string subStr = number.Substring(1, number.Length - 2);
                double numberInt = int.Parse(subStr);
                if (char.IsUpper(number[0]))
                {
                    numberInt /= PositionOfLetter(number[0]);
                }
                else
                {
                    numberInt *= PositionOfLetter(number[0]);
                }

                if (char.IsUpper(number[number.Length - 1]))
                {
                    numberInt = numberInt - PositionOfLetter(number[number.Length - 1]);
                }
                else
                {
                    numberInt = numberInt + PositionOfLetter(number[number.Length - 1]);
                }
                sum += numberInt;
            }
            Console.WriteLine($"{sum:f2}");
        }
        static double PositionOfLetter(char letter)
        {
            char lowerLetter = char.ToLower(letter);
            return 26 - (122 - (int)lowerLetter);
        }
    }
}
