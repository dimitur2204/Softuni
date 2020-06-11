using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = new StreamReader("../../../Input.txt");
            var text = new StringBuilder();
            while (true)
            {
                var line = file.ReadLine();
                if (line == null)
                {
                    break;
                }
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '-' || line[i] == ',' || line[i] == '.' || line[i] == '!' || line[i] == '?')
                    {
                        var lineSt = new StringBuilder(line);
                        lineSt[i] = '@';
                        line = lineSt.ToString();
                    }
                }
                text.AppendLine(line);
            }
            Console.WriteLine(text);
        }
    }
}
