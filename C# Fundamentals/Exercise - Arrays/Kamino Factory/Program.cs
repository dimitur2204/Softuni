using System;
using System.Linq;

namespace Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthOfSequence = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int bestDNASum = 0;
            int currentDNAIndex = 1;
            int bestDNALength = 0;
            int bestDNAIndex = 0;
            int bestStartingIndex = 0;
            int[] bestDNA = new int[lengthOfSequence];
            while (command != "Clone them!")
            {
                int[] currentDNA = new int[lengthOfSequence];
                currentDNA = command
                   .Split("!", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();
                int currentMaxDNALength = 0;
                int currentStartingIndex = 0;
                int currentSum = 0;
                for (int i = 0; i < currentDNA.Length; i++)
                {
                    currentSum += currentDNA[i];
                    int currentDNALength = 0;
                    int j = i;
                    while (currentDNA[i] == currentDNA[j])
                    {
                        currentDNALength++;
                        j++;
                        if (j == currentDNA.Length)
                        {
                            break;
                        }
                    }
                    if (currentDNALength > currentMaxDNALength)
                    {
                        currentMaxDNALength = currentDNALength;
                        currentStartingIndex = i; 
                    }
                }
                if (currentMaxDNALength > bestDNALength)
                {
                    bestDNALength = currentMaxDNALength;
                    bestStartingIndex = currentStartingIndex;
                    bestDNA = currentDNA;
                    bestDNAIndex = currentDNAIndex;
                    bestDNASum = currentSum;
                }
                else if (currentMaxDNALength == bestDNALength)
                {
                    if (currentStartingIndex < bestStartingIndex)
                    {
                        bestDNALength = currentMaxDNALength;
                        bestStartingIndex = currentStartingIndex;
                        bestDNA = currentDNA;
                        bestDNAIndex = currentDNAIndex;
                        bestDNASum = currentSum;
                    }
                    else if (currentStartingIndex == bestStartingIndex)
                    {
                        if (currentSum > bestDNASum)
                        {
                            bestDNALength = currentMaxDNALength;
                            bestStartingIndex = currentStartingIndex;
                            bestDNA = currentDNA;
                            bestDNAIndex = currentDNAIndex;
                            bestDNASum = currentSum;
                        }
                    }
                }
                currentDNAIndex++;
                command = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {bestDNAIndex} with sum: {bestDNASum}.");
            Console.WriteLine(String.Join(" ",bestDNA));
        }
    }
}
