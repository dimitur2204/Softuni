using System;

namespace Centuries_to_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            Int64 centuries = Int64.Parse(Console.ReadLine());
            decimal years = Math.Round(centuries * 100m);
            decimal days = Math.Round(years * 365.2422m);
            decimal hours = Math.Round(days * 24m);
            decimal minutes = Math.Round(hours * 60m);
            Console.WriteLine($"{centuries:f0} centuries = {years:f0} years = {days:f0} days = {hours:f0} hours = {minutes:f0} minutes ");
        }
    }
}
