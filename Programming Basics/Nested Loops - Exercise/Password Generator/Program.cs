using System;

namespace Password_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            for (int number1 = 1; number1 <= n; number1++)
            {
                for (int number2 = 1; number2 <= n; number2++)
                {
                    for (int char1 = 97; char1 < 97 + l; char1++)
                    {
                        for (int char2 = 97; char2 < 97 + l; char2++)
                        {
                            for (int number3 = 1; number3 <= n; number3++)
                            {
                                if (number3 > number2 && number3 > number1)
                                {
                                    char character1 = (char)(char1);
                                    char character2 = (char)(char2);
                                    Console.Write($"{number1}{number2}{character1}{character2}{number3} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
