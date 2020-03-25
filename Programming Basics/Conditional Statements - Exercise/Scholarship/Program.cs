using System;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averageSuccess = double.Parse(Console.ReadLine());
            double minimalWage = double.Parse(Console.ReadLine());
            double socialScholarship = 0;
            double successScholarship = 0;
            if (averageSuccess >= 4.5 && income < minimalWage)
            {
                socialScholarship = minimalWage * 0.35;
            }

            if (averageSuccess >= 5.5)
            {
                successScholarship = averageSuccess * 25;
            }

            bool socialScholarshipIsBigger = socialScholarship > successScholarship;
            bool succesScholarshipIsBigger = socialScholarship < successScholarship;

            if (socialScholarship == 0 && successScholarship == 0)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (socialScholarshipIsBigger) 
            {
                Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
            }
            else if (succesScholarshipIsBigger) 
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(successScholarship)} BGN");

            }
            else
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(successScholarship)} BGN");
            }
        }
    }
}
