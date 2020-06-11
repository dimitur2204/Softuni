namespace Odd_Lines
{
    using System;
    using System.IO;
    class Program
    {
        static void Main()
        {
            var lines = File.ReadAllLines("../../../Input.txt");
            var outputFile = File.CreateText("../../../Output.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                if (i % 2 == 1)
                {
                    outputFile.WriteLine(lines[i]);
                }
            }
            outputFile.Flush();
        }
    }
}
