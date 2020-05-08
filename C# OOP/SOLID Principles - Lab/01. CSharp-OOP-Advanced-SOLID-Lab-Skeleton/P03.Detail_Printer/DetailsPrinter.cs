using P03.Detail_Printer;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<Employee> employees;
        private IPrinter printer;

        public DetailsPrinter(IList<Employee> employees, IPrinter printer)
        {
            this.employees = employees;
            this.printer = printer;
        }

        public void PrintDetails()
        {
            foreach (Employee employee in this.employees)
            {
                
            }
        }
    }
}
