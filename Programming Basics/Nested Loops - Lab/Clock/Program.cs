using System;

namespace Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int hours = 0; hours < 24; hours++)
            {
                for (int minutes = 0; minutes < 60; minutes++)
                {
                    for (int seconds = 0; seconds < 60; seconds++)
                    {
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine($"{hours:d2}:{minutes:d2}:{seconds:d2}");
                        Console.Clear();
                        Console.WriteLine($"{hours:d2}:{minutes:d2}:{seconds:d2}");
                    }                                  
                }
            }
        }
    }
}
