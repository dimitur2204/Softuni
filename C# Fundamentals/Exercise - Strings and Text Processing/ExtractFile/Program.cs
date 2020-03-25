using System;

namespace ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separators = new char[] {':','\\','.' };
            string[] directiories = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"File name: {directiories[directiories.Length - 2]}");
            Console.WriteLine($"File extension: {directiories[directiories.Length - 1]}");

        }
    }
}
