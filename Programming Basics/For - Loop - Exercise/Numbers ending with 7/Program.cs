using System;

namespace Numbers_ending_with_7
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 997; i++)
            {
                if (i % 10 == 7)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
