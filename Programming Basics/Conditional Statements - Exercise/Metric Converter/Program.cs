using System;

namespace Metric_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberForConvertion = double.Parse(Console.ReadLine());
            string inputUnit = Console.ReadLine();
            string outputUnit = Console.ReadLine();

             if (inputUnit == "mm" )
            {
                numberForConvertion = numberForConvertion / 1000;
            }
             else if (inputUnit == "cm") 
            {
                numberForConvertion = numberForConvertion / 100;
            }
             else if (inputUnit== "m") 
            {
                numberForConvertion = numberForConvertion * 1;
            }

             if (outputUnit == "mm") 
            {
                numberForConvertion = numberForConvertion * 1000;
            }
            else if (outputUnit == "cm")
            {
                numberForConvertion = numberForConvertion * 100;
            }
            else if (outputUnit == "m")
            {
                numberForConvertion = numberForConvertion * 1 ;
            }
            Console.WriteLine($"{numberForConvertion:f3}");
        }
    }
}
