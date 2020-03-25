using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            GetMiddle(input);
        }

        static void GetMiddle(string input)
        {
            if (!(input.Length % 2 == 0))
            {
                Console.WriteLine(input[input.Length / 2].ToString()); 
            }
            else
            {
                Console.WriteLine(input[input.Length / 2 - 1].ToString() + input[input.Length / 2].ToString());
            }
        }
    }
}
