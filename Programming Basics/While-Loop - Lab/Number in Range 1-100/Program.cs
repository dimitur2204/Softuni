using System;

namespace Number_in_Range_1_100
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            while(input<1 || input > 100) 
            {
                Console.WriteLine("Invalid number!");
                input = int.Parse(Console.ReadLine());

            }

            if (input >= 1 && input <= 100)
            {
                Console.WriteLine($"The number is: {input}");
            }
        }
    }
}
