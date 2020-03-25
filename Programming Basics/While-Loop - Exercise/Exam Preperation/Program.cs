using System;

namespace Exam_Preperation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBadGrades = int.Parse(Console.ReadLine());
            string command = "";
            double averageScore;
            double grade;
            double sumOfGrades = 0;
            int badGrades = 0;
            int problemsSolved = 0;
            bool goodJob = true;
            string lastProblem = "";

            while(true) 
            {
                command = Console.ReadLine();
                if (command == "Enough")
                {
                    break;
                }
                else
                {
                    lastProblem = command;
                }

                grade = double.Parse(Console.ReadLine());
                if(grade <= 4.00) 
                {
                    badGrades++;
                }
                if (badGrades >= numberOfBadGrades)
                {
                    goodJob = false;
                    break;
                    
                }
                sumOfGrades += grade;
                problemsSolved++;
            }
            averageScore = sumOfGrades / problemsSolved;
            if (goodJob)
            {
                Console.WriteLine($"Average score: {averageScore:f2}");
                Console.WriteLine($"Number of problems: {problemsSolved}");
                Console.WriteLine($"Last problem: {lastProblem}"); 

            }
            else
            {
                Console.WriteLine($"You need a break, {badGrades} poor grades."); 
            }
        }
    }
}
