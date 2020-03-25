using System;
using System.Collections.Generic;

namespace _05._Students
{

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Student> students = new List<Student>();
            while (input != "end")
            {
                //John Smith 15 Sofia
                Student currentStudent = new Student();
                string[] inputSeperated = input.Split();
                currentStudent.FirstName = inputSeperated[0];
                currentStudent.LastName = inputSeperated[1];
                currentStudent.Age = int.Parse(inputSeperated[2]);
                currentStudent.Hometown = inputSeperated[3];
                students.Add(currentStudent);
                input = Console.ReadLine();
            }
            string wantedTown = Console.ReadLine();
            foreach (var student in students)
            {
                if (student.Hometown == wantedTown)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }
}
