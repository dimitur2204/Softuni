using System;
using System.Linq;
using System.Text;

namespace Username
{
    class Program
    {
        static void Main(string[] args)
        {
            var username = new StringBuilder(Console.ReadLine());
            var command = Console.ReadLine();
            while (command!="Sign up")
            {
                var tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Case")
                {
                    if (tokens[1] == "upper")
                    {
                        username = new StringBuilder(username.ToString().ToUpper());
                    }
                    else
                    {
                        username = new StringBuilder(username.ToString().ToLower());
                    }
                    Console.WriteLine(username);
                }
                else if (tokens[0] == "Reverse")
                {
                    var start = int.Parse(tokens[1]);
                    var end = int.Parse(tokens[2]);
                    if (isIndexValid(start,username) && isIndexValid(end,username))
                    {
                        var substring = username
                            .ToString()
                            .Substring(start, end - start + 1);
                        var reversed = "";
                        for (int i = substring.Length - 1; i >= 0; i--)
                        {
                            reversed += substring[i];
                        }
                        Console.WriteLine(reversed);
                    }
                }
                else if (tokens[0] == "Cut")
                {
                    var substring = tokens[1];
                    if (username.ToString().Contains(substring))
                    {
                        username.Replace(substring,"");
                    }
                    else
                    {
                        Console.WriteLine($"The word {username} doesn't contain {substring}.");
                    }
                    Console.WriteLine(username);
                }
                else if (tokens[0] == "Replace")
                {
                    var symbol = tokens[1];
                    username.Replace(symbol, "*");
                    Console.WriteLine(username);
                }
                else if (tokens[0] == "Check")
                {
                    var symbol = tokens[1];
                    if (username.ToString().Contains(symbol))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {symbol}.");
                    }
                }
                command = Console.ReadLine();
            }
        }
        public static bool isIndexValid(int index, StringBuilder stringBuilder) 
        {
            if (index < 0 || index >= stringBuilder.Length)
            {
                return false;
            }
            return true;

        }
    }
}
