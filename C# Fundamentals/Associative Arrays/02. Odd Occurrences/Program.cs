using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split();
            Dictionary<string, int> wordsOccuruncies = new Dictionary<string, int>();
            foreach (var word in words)
            {
                string newWord = word.ToLower();
                if (wordsOccuruncies.ContainsKey(newWord))
                {
                    wordsOccuruncies[newWord]++;
                }
                else
                {
                    wordsOccuruncies[newWord] = 1;
                }        
            }
            Console.WriteLine(String.Join(" ", wordsOccuruncies.Where(x => x.Value % 2 != 0).Select(x => x.Key)));
        }
    }
}
