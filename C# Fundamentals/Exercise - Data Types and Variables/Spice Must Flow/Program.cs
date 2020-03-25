using System;

namespace Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int numberOfDays = 0;
            int spicesExtracted = 0;
            if (startingYield < 100)
            {
                Console.WriteLine(numberOfDays);
                Console.WriteLine(spicesExtracted);
                return;
            }
            while (startingYield >= 100)
            {
                spicesExtracted += startingYield;
                startingYield -= 10;
                numberOfDays++;
                spicesExtracted -= 26;
            }
            spicesExtracted -= 26;
            Console.WriteLine(numberOfDays);
            Console.WriteLine(spicesExtracted);
            
        }
    }
}
