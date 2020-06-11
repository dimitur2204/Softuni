using System;
using System.IO;

namespace Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = File.ReadAllBytes("../../../Mom4eto - Freestyle.mp3");
            var newFile = File.Create("../../../CopiedMomi.mp3");
            for (int i = 0; i < file.Length; i++)
            {
                newFile.WriteByte(file[i]);
            }
            newFile.Flush();
        }
    }
}
