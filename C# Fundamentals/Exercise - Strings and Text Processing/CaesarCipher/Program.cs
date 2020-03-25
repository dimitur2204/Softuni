using System;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string encryptedInput = "";
            foreach (var symbol in input)
            {
                char newSymbol = (char)((int)symbol + 3);
                encryptedInput += newSymbol;
            }
            Console.WriteLine(encryptedInput);
        }
    }
}
