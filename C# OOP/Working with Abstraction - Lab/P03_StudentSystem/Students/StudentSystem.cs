using System;
using System.Collections.Generic;
using System.Text;

namespace _03StudentSystem
{
    public class StudentSystem
    {
        public StudentSystem()
        {
            this.Students = new Dictionary<string, Student>();
        }

        public Dictionary<string, Student> Students { get; private set; }
        public Student Get(string name)
        {
            if (!Students.ContainsKey(name))
            {
                throw new InvalidOperationException();
            }
            if (Students.ContainsKey(name))
            {
                var student = this.Students[name];
                return student;
            }
            return null;
        }
        public void Add(string name, int age, double grade)
        {
            if (!Students.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                Students[name] = student;
            }
        }
    }
}
