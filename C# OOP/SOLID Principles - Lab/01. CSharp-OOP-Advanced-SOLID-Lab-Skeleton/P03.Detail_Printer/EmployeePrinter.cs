using P03.DetailPrinter;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer
{
    public class EmployeePrinter : IPrinter
    {
        public EmployeePrinter(Employee employee)
        {
            this.Employee = employee;
        }
        public Employee Employee { private get; set; }
        public void Print()
        {
            Console.WriteLine(Employee.Name);
        }
    }
}
