
namespace Word_Count
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var words = File.ReadAllText("../../../Words.txt").Split();
            var wordsFrequency = new Dictionary<string, int>();
            foreach (var word in words)
            {
                wordsFrequency.Add(word,0);
            }
            var input = File.ReadAllText("../../../Input.txt");
            var separators = new char[] 
            {
                ',',
                ' ',
                '-',
                '!',
                '.',
                '?'
            };
            var wordsInInput = input.Split(separators,StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in wordsInInput)
            {
                if (wordsFrequency.ContainsKey(word.ToLower()))
                {
                    wordsFrequency[word.ToLower()]++;
                }
            }
            var output = File.CreateText("../../../Output.txt");
            foreach (var (word,times) in wordsFrequency.OrderByDescending(x => x.Value))
            {
                output.WriteLine($"{word} - {times}");
            }
            output.Flush();
        }
    }
}
