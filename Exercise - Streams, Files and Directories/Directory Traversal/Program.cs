using System;
using System.Collections.Generic;
using System.IO;

namespace Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = new DirectoryInfo(@"C:\Users\dimit\OneDrive\Desktop\Softuni\C# Advanced\Multidimensional Arrays - Exercise\Knight Game\bin\Debug\netcoreapp3.1");
            var files = directory.GetFiles();
            var filesWithExt = new Dictionary<string,List<string>>();
            foreach (var file in files)
            {
                if (!filesWithExt.ContainsKey(file.Extension))
                {
                    filesWithExt.Add(file.Extension, new List<string>());
                }
                filesWithExt[file.Extension].Add(file.FullName);
            }
            var reportFile = File.CreateText("../../../Report.txt");
        }
    }
}
