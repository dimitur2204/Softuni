using System;
using System.IO;

namespace Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("../../../Input.txt");
            var output = File.CreateText("../../../Output.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                output.WriteLine($"{i + 1}. {lines[i]}");
            }
            output.Flush();
        }
    }
}
