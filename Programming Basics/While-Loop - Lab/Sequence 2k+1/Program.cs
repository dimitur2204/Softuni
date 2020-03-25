using System;

namespace Sequence_2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int counter = 1;
            while (counter <= input)
            {
                Console.WriteLine(counter);
                counter = (counter * 2) + 1;
            }
        }
    }
}
