using System;

namespace CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var strings = Console.ReadLine().Split();
            var input1 = strings[0];
            var input2 = strings[1];
            var sum = GetSumOfChars(input1, input2);
            Console.WriteLine(sum);
        }
        static int GetSumOfChars(string input1, string input2) 
        {
            var minLength = Math.Min(input1.Length, input2.Length);
            var sumOfChars = 0;
            for (int i = 0; i < minLength; i++)
            {
                var sumToAdd = (int)input1[i] * (int)input2[i];
                sumOfChars += sumToAdd;
            }
            string remaining = GetRemaining(input1, input2);
            foreach (var symbol in remaining)
            {
                sumOfChars += (int)symbol;
            }
            return sumOfChars;
        }
        static string GetRemaining(string input1, string input2) 
        {
            string remaining = "";
            if (input1.Length > input2.Length)
            {
                 remaining = input1.Substring(input2.Length, input1.Length - input2.Length);
            }
            else
            {
                remaining = input2.Substring(input1.Length, input2.Length - input1.Length);
            }
            return remaining;
        }
    }
}
