using System;

namespace _1._Sign_of_Integer_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double result = GetRectangleArea(width, length);
            Console.WriteLine(result);
        }

        private static double GetRectangleArea(double w , double l)
        {
            double result = w * l;
            return result;
        }
    }
}
