using System;

namespace Bonus_Score
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            double bonusPoints = 0;
            if (number > 1000)
            {
                bonusPoints = number * 0.1;
            }
            else if (number > 100)
            {
                bonusPoints = number * 0.2;
            }
            else if (number <= 100) 
            {
                bonusPoints = 5;
            }

            if (number % 2 == 0) 
            {
                bonusPoints = bonusPoints + 1;
            }

            if (number % 10 == 5) 
            {
                bonusPoints = bonusPoints + 2;
            }
            double sumPoints = number + bonusPoints;
            Console.WriteLine(bonusPoints);
            Console.WriteLine(sumPoints);

        }
    }
}
