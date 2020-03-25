using System;
using System.Linq;

namespace Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {            //First Solution
            //int maxSeqStartingIndex = 0;
            //int maxSeqEndingIndex = 0;
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    int currentSequenceLength = 0;
            //    int j = i;
            //    while (arr[i] == arr[j])
            //    {
            //        currentSequenceLength++;
            //        j++;
            //        if (j == arr.Length)
            //        {
            //            break;
            //        }
            //    }
            //    if (currentSequenceLength > maxSequenceLength)
            //    {
            //        maxSequenceLength = currentSequenceLength;
            //        maxSeqStartingIndex = i;
            //        maxSeqEndingIndex = j - 1;
            //    }
            //}
            //for (int i = maxSeqStartingIndex; i <= maxSeqEndingIndex; i++)
            //{
            //    Console.Write(arr[i] + " ");
            //}

            //Second Solution
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int maxSequenceLength = 0;
            int maxSequenceNumber = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int currentSequenceLength = 0;
                int j = i;
                while (arr[i] == arr[j])
                {
                    currentSequenceLength++;
                    j++;
                    if (j == arr.Length)
                    {
                        break;
                    }
                }
                if (currentSequenceLength > maxSequenceLength)
                {
                    maxSequenceLength = currentSequenceLength;
                    maxSequenceNumber = arr[i];
                }
            }
            for (int i = 0; i < maxSequenceLength; i++)
            {
                Console.Write(maxSequenceNumber + " ");
            }
        }
    }
}
