using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> getMin = (input) => { return input.Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList().Min(); };
            Console.WriteLine(getMin(Console.ReadLine()));
        }
    }
}
