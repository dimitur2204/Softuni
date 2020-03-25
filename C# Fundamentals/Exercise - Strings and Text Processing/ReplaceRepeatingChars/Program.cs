using System;
using System.Text;

namespace ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());
            string uniqueInput = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (i + 1 >= input.Length)
                {
                    uniqueInput += input[i];
                    break;
                }
                while (input[i] == input[i+1])
                {
                    i++;
                    if (i + 1 >= input.Length)
                    {
                        uniqueInput += input[i];
                        Console.WriteLine(uniqueInput);
                        return;
                    }
                }
                uniqueInput += input[i];
            }
            Console.WriteLine(uniqueInput);
        }
    }
}
