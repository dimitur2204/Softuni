using System;

namespace Freelance
{
    class Program
    {
        static void Main(string[] args)
        {
            double sumForCar = double.Parse(Console.ReadLine());
            double expensesEveryMonth = double.Parse(Console.ReadLine());
            double sumSaved = 0;
            int numberOfMonths = 0;
            int numberOfYears = 0;
            while (sumSaved < sumForCar && sumSaved >= 0)
            {
                double monthlyEarnings = double.Parse(Console.ReadLine());
                sumSaved = sumSaved + (monthlyEarnings - expensesEveryMonth);
                numberOfMonths++;
            }
            while (numberOfMonths >=12)
            {
                numberOfMonths = numberOfMonths - 12;
                numberOfYears++;
            }
            if (sumSaved < 0)
            {
                Console.WriteLine("It seems you have bankrupted...");
                Console.WriteLine($"You have worked {numberOfYears} years {numberOfMonths} months");
            }
            else if (sumSaved >=0)
            {
                Console.WriteLine("You did it!");
                Console.WriteLine($"It took you {numberOfYears} years {numberOfMonths} months");
            }
        }
    }
}
