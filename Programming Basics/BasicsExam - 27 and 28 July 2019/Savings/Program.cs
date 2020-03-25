using System;

namespace Savings
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            int numberOfMonths = int.Parse(Console.ReadLine());
            double personalNeeds = double.Parse(Console.ReadLine());
            double unexpectedExpenses = 0.3 * income;
            double moneySavedPerMonth = income - (personalNeeds + unexpectedExpenses);
            double percentOfIncomeSaved = (moneySavedPerMonth / income) * 100;
            double maxMoneySaved = moneySavedPerMonth * numberOfMonths;
            Console.WriteLine($"She can save {percentOfIncomeSaved:f2}%");
            Console.WriteLine($"{maxMoneySaved:f2}");
        }
    }
}
