using System;

namespace Login
{
    class Program
    {
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Reverse(username);
            string inputPassword = Console.ReadLine();
            int invalidTries = 0;
            while (inputPassword != password)
            {
                
                invalidTries++;
                if (invalidTries >= 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }
                Console.WriteLine("Incorrect password. Try again.");
                inputPassword = Console.ReadLine();
            }
            if (inputPassword == password)
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }
    }
}
