using System;
using System.Collections.Generic;
using System.Linq;
namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();
            var courses = new Dictionary<string, List<string>>();
            while (command != "end")
            {
                var tokens = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                var course = tokens[0];
                var studentName = tokens[1];
                if (courses.ContainsKey(course))
                {
                    courses[course].Add(studentName);
                }
                else
                {
                    courses.Add(course, new List<string> {studentName});
                }
                command = Console.ReadLine();
            }
            courses = courses.OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                var orderedStudents = item.Value.OrderBy(x => x);
                foreach (var student in orderedStudents)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}