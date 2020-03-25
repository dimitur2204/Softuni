using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Nikulden_s_Charity
{
    class Program
    {
        static void Main(string[] args)
        {
            var encrypted = new StringBuilder(Console.ReadLine());
            var command = Console.ReadLine();
            while (command != "Finish")
            {
                var tokens = command.Split();
                if (tokens[0] == "Replace")
                {
                    encrypted.Replace(tokens[1], tokens[2]);
                    Console.WriteLine(encrypted);
                }
                else if (tokens[0] == "Cut")
                {
                    var startIndex = int.Parse(tokens[1]);
                    var endIndex = int.Parse(tokens[2]);
                    if (IsIndexValid(startIndex, encrypted) && IsIndexValid(endIndex, encrypted))
                    {
                        encrypted.Remove(startIndex, endIndex - startIndex + 1);
                        Console.WriteLine(encrypted);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                        command = Console.ReadLine();
                        continue;
                    }
                }
                else if (tokens[0] == "Make")
                {
                    if (tokens[1] == "Upper")
                    {
                        encrypted = new StringBuilder(encrypted.ToString().ToUpper());
                        Console.WriteLine(encrypted);
                    }
                    else
                    {
                        encrypted = new StringBuilder(encrypted.ToString().ToLower());
                        Console.WriteLine(encrypted);
                    }
                }
                else if (tokens[0] == "Check")
                {
                    var message = tokens[1];
                    if (encrypted.ToString().Contains(message))
                    {
                        Console.WriteLine($"Message contains {message}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {message}");
                    }
                }
                else if (tokens[0] == "Sum")
                {
                    var startIndex = int.Parse(tokens[1]);
                    var endIndex = int.Parse(tokens[2]);
                    if (IsIndexValid(startIndex, encrypted) && IsIndexValid(endIndex, encrypted))
                    {
                        int sum = 0;
                        foreach (var symbol in encrypted.ToString().Substring(startIndex, endIndex - startIndex + 1))
                        {
                            sum += (int)symbol;
                        }
                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                        command = Console.ReadLine();
                        continue;
                    }
                }
                command = Console.ReadLine(); 
            }
        }
        static bool IsIndexValid(int index, StringBuilder enumbrable) 
        {
            if (index < 0 || index >= enumbrable.Length)
            {
                return false;
            }
            return true;
        }
    }
}
