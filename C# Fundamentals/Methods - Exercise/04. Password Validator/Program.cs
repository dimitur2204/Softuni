using System;
using System.Threading.Channels;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool isValid = true;
            if (!SixToTen(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                isValid = false;
            }
            if (!OnlyLettersAndDigits(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
                isValid = false;
            }
            if (!AtLeastTwoDigits(password))
            {
                Console.WriteLine("Password must have at least 2 digits");
                isValid = false;
            }
            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool AtLeastTwoDigits(string password)
        {
            int countOfDigits = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 48 && password[i] <= 57)
                {
                    countOfDigits++;
                }
            }
            return countOfDigits >= 2;
        }

        private static bool OnlyLettersAndDigits(string password)
        {
            bool isValid = true;
            for (int i = 0; i < password.Length; i++)
            {
                if (!(password[i] >= 48 && password[i] <=57 || password[i] >= 65 && password[i] <= 90 
                    || password[i] >= 97 && password[i] <= 122))
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        private static bool SixToTen(string password)
        {
            if (password.Length < 6 || password.Length > 10)
            {
                return false;
            }
            else 
            {
            return true;
            }      
        }

    }
}



