using System;

namespace Savings
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double sumNeeded = double.Parse(Console.ReadLine());
            double unexpSit = 0.3 * income;          
            double sumSavedPerMonth = income - (sumNeeded + unexpSit);
            double maxPercent = (sumSavedPerMonth / income)*100;
            double sumSaved = sumSavedPerMonth * months;
            Console.WriteLine($"She can save {maxPercent:f2}%");
            Console.WriteLine($"{sumSaved:f2}");
        }
    }
}
