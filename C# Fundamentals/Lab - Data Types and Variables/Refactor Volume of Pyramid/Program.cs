using System;

namespace Refactor_Volume_of_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Length: ");
            decimal length = decimal.Parse(Console.ReadLine());
            Console.Write("Width: ");
            decimal width = decimal.Parse(Console.ReadLine());
            Console.Write("Height: ");
            decimal height = decimal.Parse(Console.ReadLine());
            decimal refactoredVolume = (length + width + height) /3m ;
            Console.Write($"Pyramid Volume: {refactoredVolume:f2}");
        }
    }
}
