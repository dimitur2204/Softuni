using System;

namespace Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLetters = int.Parse(Console.ReadLine());
            for (int i = 97; i < numberOfLetters + 97; i++)
            {
                for (int j = 97; j < numberOfLetters + 97; j++)
                {
                    for (int k = 97; k < numberOfLetters + 97; k++)
                    {
                        Console.WriteLine($"{(char)(i)}{(char)(j)}{(char)(k)}");
                    }
                }
            }
        }
    }
}
