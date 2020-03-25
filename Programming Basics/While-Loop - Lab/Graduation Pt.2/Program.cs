using System;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int counter = 12;
            double sumOfGrades = 0;
            int timesExcluded = 0 ;
            while (counter != 0)
            {    
                double grade = double.Parse(Console.ReadLine());
                sumOfGrades += grade;

                if (grade < 4.00)
                {
                    timesExcluded++;
                }

                if (timesExcluded == 2)
                {
                    Console.WriteLine($"{name} has been excluded at {12 - counter} grade");
                    return;   
                }
                counter--;
            }

            double average = sumOfGrades / 12.0;

            if (average >= 4.00)
            {
                Console.WriteLine($"{name} graduated. Average grade: {average:f2}");
            }
        }
    }
}
