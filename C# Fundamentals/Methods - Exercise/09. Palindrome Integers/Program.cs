using System;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            while (command != "END")
            {
                if (IsPalindrome(command))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
                command = Console.ReadLine();
            }
        }
        static bool IsPalindrome(string num) 
        {
            bool isPal = false;
            string numBackwards = "";
            for (int i = 0; i < num.Length; i++)
            {
                numBackwards += num[num.Length - i - 1];
            }
            if (numBackwards == num)
            {
                isPal = true;
            }
            return isPal;
        }
    }
}
