using P03.DetailPrinter;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer
{
    public class ManagerPrinter : IPrinter
    {
        public ManagerPrinter(Manager manager)
        {
            this.manager = manager;
        }
        public Manager manager {private get; set; }
        public void Print()
        {
            Console.WriteLine(manager.Name);
            Console.WriteLine(string.Join(Environment.NewLine, manager.Documents));
        }
    }
}
