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

            while (counter != 0)
            {
                counter--;
                double grade = double.Parse(Console.ReadLine());
                sumOfGrades += grade;
            }

            double average = sumOfGrades / 12.0;

            if (average >= 4.00)
            {
                Console.WriteLine($"{name} graduated. Average grade: {average:f2}");
            }
        }
    }
}
