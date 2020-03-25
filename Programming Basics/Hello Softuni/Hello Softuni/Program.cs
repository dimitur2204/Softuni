using System;

namespace Hello_Softuni
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percentOfUsedSpace = double.Parse(Console.ReadLine());
            int volume = length * width * height;
            double volumeInLitres = volume * 0.001;
            double litresNeededToFill = volumeInLitres * (1 - (percentOfUsedSpace / 100));
            Console.WriteLine($"{litresNeededToFill:F3}");
        }
    }
}
