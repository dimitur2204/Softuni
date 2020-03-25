using System;

namespace Numbers_1_to_N_with_Step_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNumbers = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numberOfNumbers; i += 3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
