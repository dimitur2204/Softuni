using System;

namespace Pounds_to_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal inputDollars = decimal.Parse(Console.ReadLine());
            decimal outputPounds = inputDollars * 1.31m;
            Console.WriteLine($"{outputPounds:f3}");
        }
    }
}
