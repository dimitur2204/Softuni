using System;
using System.IO;

namespace Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstInput = File.ReadAllLines("../../../Input1.txt");
            var secondInput = File.ReadAllLines("../../../Input2.txt");
            var output = File.CreateText("../../../Output.txt");
            for (int i = 0; i < Math.Min(firstInput.Length,secondInput.Length); i++)
            {
                output.WriteLine(firstInput[i]);
                output.WriteLine(secondInput[i]);
            }
           
        }
    }
}
