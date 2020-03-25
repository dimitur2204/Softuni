using System;

namespace Divide_without_remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNumbers = int.Parse(Console.ReadLine());
            double br2 = 0.0;
            double br3 = 0.0;
            double br4 = 0.0;
            for (int i = 0; i < numberOfNumbers; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());
                if (inputNumber % 2 == 0)
                {
                    br2++;
                }
                 if (inputNumber % 4 == 0)
                {
                    br4++;
                }
                if (inputNumber % 3 == 0)
                {
                    br3++;
                }
            }
            double percentage2 = (br2 / numberOfNumbers) * 100;
            double percentage3 = (br3 / numberOfNumbers) * 100;
            double percentage4 = (br4 / numberOfNumbers) * 100;
            Console.WriteLine($"{percentage2:f2}%");
            Console.WriteLine($"{percentage3:f2}%");
            Console.WriteLine($"{percentage4:f2}%");
        }
    }
}
