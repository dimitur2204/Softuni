using System;
using System.Text;
using System.Linq;
namespace Email_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            var email = new StringBuilder(Console.ReadLine());
            var command = Console.ReadLine();
            while (command != "Complete")
            {
                var tokens = command.Split();
                if (tokens[0] == "Make"&&tokens[1] == "Upper")
                {
                    email = new StringBuilder(email.ToString().ToUpper());
                    Console.WriteLine(email);
                }
                else if (tokens[0] == "Make"&&tokens[1] == "Lower")
                {
                    email = new StringBuilder(email.ToString().ToLower());
                    Console.WriteLine(email);
                }
                else if (tokens[0] == "GetDomain")
                {
                    var count = int.Parse(tokens[1]);
                    Console.WriteLine(email.ToString().Substring(email.Length - count,count));
                }
                else if (tokens[0] == "GetUsername")
                {
                    if (email.ToString().Contains('@'))
                    {
                        Console.WriteLine(email.ToString()
                            .Substring
                            (0,email
                            .ToString()
                            .IndexOf('@'))
                            );
                    }
                    else
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }
                }
                else if (tokens[0] == "Replace")
                {
                    email = new StringBuilder(email.Replace(tokens[1].ToString().ToCharArray()[0],'-').ToString());
                    Console.WriteLine(email);
                }
                else if (tokens[0] == "Encrypt")
                {
                    foreach (var symbol in email.ToString())
                    {
                        Console.Write((int)symbol + " ");
                    }
                }
                command = Console.ReadLine();
            }
        }
    }
}
