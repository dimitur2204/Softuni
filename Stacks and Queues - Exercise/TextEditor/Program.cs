using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfCommands = int.Parse(Console.ReadLine());
            var text = new StringBuilder();
            var textGenerations = new Stack<string>();
            for (int i = 0; i < numberOfCommands; i++)
            {
                var tokens = Console.ReadLine().Split();
                var command = tokens[0];
                if (command == "1")
                {
                    var arguments = tokens[1];
                    textGenerations.Push(text.ToString());
                    text.Append(arguments);
                }
                else if (command == "2")
                {
                    var arguments = tokens[1];
                    textGenerations.Push(text.ToString());
                    var count = int.Parse(arguments);
                    text.Remove(text.Length - count,count);
                }
                else if (command == "3")
                {
                    var arguments = tokens[1];
                    var index = int.Parse(arguments);
                    Console.WriteLine(text[index - 1]);
                }
                else
                {
                    text = new StringBuilder(textGenerations.Pop());
                }
            }
        }
    }
}
