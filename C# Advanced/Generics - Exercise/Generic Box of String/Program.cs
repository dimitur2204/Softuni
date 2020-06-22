using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace GenericBox 
{ 
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var list = new List<Box<double>>();
            for (int i = 0; i < n; i++)
            {
                list.Add(new Box<double>(double.Parse(Console.ReadLine())));
            }

            var comparisonString = double.Parse(Console.ReadLine());
            var count = Box<double>.CompareDouble(list,comparisonString);
            Console.WriteLine(count);
        }
    }
}
