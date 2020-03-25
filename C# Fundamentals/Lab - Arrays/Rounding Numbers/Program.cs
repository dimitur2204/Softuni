using System;
using System.Linq;

namespace Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] realNumbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();
            int[] roundedNums = new int[realNumbers.Length];
            for (int i = 0; i < roundedNums.Length; i++)
            {  
                roundedNums[i] = (int)Math.Round(realNumbers[i], MidpointRounding.AwayFromZero);        
            }
            for (int i = 0; i < roundedNums.Length; i++)
            {
                Console.WriteLine(realNumbers[i] + " " + "=>" + " " + roundedNums[i]);
            }          
        }
    }
}
