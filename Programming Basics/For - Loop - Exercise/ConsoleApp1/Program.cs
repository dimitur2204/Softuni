using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNumbers = int.Parse(Console.ReadLine());
            double brUnder200 = 0.0;
            double br200to399 = 0.0;
            double br400to599 = 0.0;
            double br600to799 = 0.0;
            double brOver800 = 0.0;
            for (int i = 0; i < numberOfNumbers; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());
                if (inputNumber < 200)
                {
                    brUnder200++;
                }
                else if (inputNumber >= 200 && inputNumber < 400)
                {
                    br200to399++;
                }
                else if (inputNumber >= 400 && inputNumber < 600)
                {
                    br400to599++;
                }
                else if (inputNumber >= 600 && inputNumber < 800)
                {
                    br600to799++;
                }
                else if (inputNumber >= 800)
                {
                    brOver800++;
                }
            }
            double percentageUnder200 = (brUnder200 / numberOfNumbers) * 100;
            double percentage200to399 = (br200to399 / numberOfNumbers) * 100;
            double percentage400to599 = (br400to599 / numberOfNumbers) * 100;
            double percentage600to799 = (br600to799 / numberOfNumbers) * 100;
            double percentageOver800 = (brOver800 / numberOfNumbers) * 100;
            Console.WriteLine($"{percentageUnder200:f2}%");
            Console.WriteLine($"{percentage200to399:f2}%");
            Console.WriteLine($"{percentage400to599:f2}%");
            Console.WriteLine($"{percentage600to799:f2}%");
            Console.WriteLine($"{percentageOver800:f2}%");
        }
    }
}
