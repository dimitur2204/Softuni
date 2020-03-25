using System;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine()); 
            int c = int.Parse(Console.ReadLine()); 
            int d = int.Parse(Console.ReadLine());
            for (int firstRowFirst = a; firstRowFirst <= b; firstRowFirst++)
            {
                for (int firstRowSecond = a; firstRowSecond <= b; firstRowSecond++)
                {
                    for (int secondRowFirst = c; secondRowFirst <= d; secondRowFirst++)
                    {
                        for (int secondRowSecond = c; secondRowSecond <= d; secondRowSecond++)
                        {
                            if ((firstRowFirst + secondRowSecond) == (firstRowSecond + secondRowFirst) && (firstRowFirst != firstRowSecond) && (secondRowFirst != secondRowSecond))
                            {
                                Console.WriteLine($"{firstRowFirst}{firstRowSecond}");
                                Console.WriteLine($"{secondRowFirst}{ secondRowSecond}");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
        }
    }
}
