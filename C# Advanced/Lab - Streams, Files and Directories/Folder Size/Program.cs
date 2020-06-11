using System;
using System.IO;

namespace Folder_Size
{
    class Program
    {
        static long size = 0;
        static void Main(string[] args)
        {
            var directoryInfo = new DirectoryInfo("../../../TestFolder");
            GetAllFilesSize(directoryInfo);
            var output = File.CreateText("../../../Output.txt");
            output.Write(size / 1024m / 1024m);
            output.Flush();
        }

        private static void GetAllFilesSize(DirectoryInfo directoryInfo)
        {
            foreach (var subDir in directoryInfo.GetDirectories())
            {
                GetAllFilesSize(subDir);
                foreach (var file in subDir.GetFiles())
                {
                    size += file.Length;
                }
            }
        }
    }
}
