using System;

namespace Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            for (int i = 0; i < words.Length; i++)
            {
                Console.Write(words[words.Length - i - 1] + " ");
            }
        }
    }
}
