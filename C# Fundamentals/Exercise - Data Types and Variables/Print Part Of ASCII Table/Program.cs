using System;

namespace Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int finish = int.Parse(Console.ReadLine());
            for (char i = (char)start; i <= (char)finish; i++)
            {
                Console.Write(i + " ");
            }
        }
    }
}
