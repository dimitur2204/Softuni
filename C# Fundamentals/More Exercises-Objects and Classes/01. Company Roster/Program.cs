using System;
using System.Collections.Generic;
using System.Linq;
namespace _01._Company_Roster
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            List<Department> departments = new List<Department>();
            for (int i = 0; i < numberOfLines; i++)
            {
                string[] employeeInformation = Console.ReadLine().Split();
                if (!departments.Any(x => x.DepartmentName == employeeInformation[2]))
                {
                    Department department = new Department(employeeInformation[2]);
                    departments.Add(department);
                }
                departments.Find(x => x.DepartmentName == employeeInformation[2]).AddNewEmployee(employeeInformation[0], double.Parse(employeeInformation[1]));
            }
            Department bestDepartment = departments.OrderByDescending(x => x.GetAverageSalary()).First();
            Console.WriteLine($"Highest Average Salary: {bestDepartment.DepartmentName}");
            foreach (var employee in bestDepartment.Employees.OrderByDescending(e => e.salary))
            {
                Console.WriteLine($"{employee.name} {employee.salary:F2}");
            }
        }
    }
}
