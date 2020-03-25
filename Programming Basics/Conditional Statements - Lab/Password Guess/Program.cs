using System;

namespace Password_Guess
{
    class Program
    {
        static void Main(string[] args)
        {
            string passwordClient = Console.ReadLine();
            string password = "s3cr3t!P@ssw0rd";
            if (passwordClient == password)
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
