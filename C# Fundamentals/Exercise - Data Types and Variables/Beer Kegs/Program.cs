using System;

namespace Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfKegs = int.Parse(Console.ReadLine());
            string biggestModel = "";
            double biggestVolume = 0;
            for (int kegNumber = 1; kegNumber <= numberOfKegs; kegNumber++)
            {
                string kegModel = Console.ReadLine();
                double kegRadius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double volumeOfKeg = Math.PI * Math.Pow(kegRadius, 2) * height;
                if (kegNumber == 1)
                {
                     biggestVolume = volumeOfKeg;
                    biggestModel = kegModel;
                }
                else
                {
                    if (volumeOfKeg >= biggestVolume)
                    {
                        biggestVolume = volumeOfKeg;
                        biggestModel = kegModel;
                    }
                }
            }
            Console.WriteLine(biggestModel);
        }
    }
}
