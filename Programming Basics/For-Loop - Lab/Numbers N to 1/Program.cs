using System;

namespace Numbers_N_to_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNumbers = int.Parse(Console.ReadLine());

            for (int i = numberOfNumbers; i > 0; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}
