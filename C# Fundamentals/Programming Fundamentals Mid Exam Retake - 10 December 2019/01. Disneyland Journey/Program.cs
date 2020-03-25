using System;

namespace _01._Disneyland_Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double journeyPrice = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double sumSaved = 0;
            for (int i = 1; i <= months; i++)
            {
                if (i == 1)
                {
                    sumSaved += 0.25 * journeyPrice;
                }
                else
                {
                    if (i % 2 == 1)
                    {
                        sumSaved -= 0.16 * sumSaved;
                    }

                    if (i % 4 == 0)
                    {
                        sumSaved += 0.25 * sumSaved;
                    }

                    sumSaved += 0.25 * journeyPrice;
                }
            }

            if (sumSaved >= journeyPrice)
            {
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {(sumSaved - journeyPrice):f2}lv. for souvenirs.");
            }
            else
            {
                Console.WriteLine($"Sorry. You need {(journeyPrice - sumSaved):f2}lv. more.");
            }

        }
    }
}
