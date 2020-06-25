using System;
using System.Text;

namespace String_Manipulator___Group_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var myString = new StringBuilder(Console.ReadLine());
            var command = Console.ReadLine();
            while (command!="Done")
            {
                var tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Change")
                {
                    var symbol = tokens[1];
                    var replacement = tokens[2];
                    myString = myString.Replace(symbol, replacement);
                    Console.WriteLine(myString);
                }
                else if (tokens[0] == "Includes")
                {
                    var substring = tokens[1];
                    Console.WriteLine(myString.ToString().Contains(substring));   
                }
                else if (tokens[0] == "End")
                {
                    var substring = tokens[1];
                    Console.WriteLine(myString.ToString().EndsWith(substring));
                }
                else if (tokens[0] == "Uppercase")
                {
                    myString = new StringBuilder(myString.ToString().ToUpper());
                    Console.WriteLine(myString);
                }
                else if (tokens[0] == "FindIndex")
                {
                    var symbol = tokens[1];
                    Console.WriteLine(myString.ToString().IndexOf(symbol));
                }
                else if (tokens[0] == "Cut")
                {
                    var startIndex = int.Parse(tokens[1]);
                    var length = int.Parse(tokens[2]);
                    myString =new StringBuilder(myString.ToString().Substring(startIndex, length));
                    Console.WriteLine(myString);
                }
                command = Console.ReadLine();
            }
        }
    }
}
