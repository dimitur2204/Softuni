using System;

namespace Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int juryPeople = int.Parse(Console.ReadLine());
            string presentationName = Console.ReadLine();
            double averageGrade = 0.0;
            double sumOfGradesPerPresentation = 0.0;
            int presenationCounter = 0;
            while (presentationName != "Finish")
            {
                double sumOfGrades = 0.0;
                double averageGradePerPresenation = 0.0;
                for (int i = 0; i < juryPeople; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    sumOfGrades += grade;
                }
                averageGrade = sumOfGrades / juryPeople;
                presenationCounter++;
                sumOfGradesPerPresentation += averageGrade;
                Console.WriteLine($"{presentationName:f2} - {averageGrade:f2}."); 
                presentationName = Console.ReadLine();
            }
            Console.WriteLine($"Student's final assessment is {sumOfGradesPerPresentation/presenationCounter:f2}.");
        }
    }
}
