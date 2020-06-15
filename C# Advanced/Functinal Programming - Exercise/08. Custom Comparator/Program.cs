using System;
using System.Collections;
using System.Linq;

namespace _08._Custom_Comparator
{
    class SortEvenFirst : IComparer
    {
        public int Compare(object x, object y)
        {
            if ((int)x % 2 == 0 && (int)y % 2 == 0 && (int)x > (int)y)
            {
                return 1;
            }
            else if ((int)x % 2 == 0 && (int)y % 2 == 0 && (int)x < (int)y)
            {
                return -1;
            }
            else if ((int)x % 2 == 0 && (int)y % 2 == 0 && (int)x == (int)y)
            {
                return 0;
            }
            else if ((int)x % 2 != 0 && (int)y % 2 != 0 && (int)x < (int)y)
            {
                return -1;
            }
            else if ((int)x % 2 != 0 && (int)y % 2 != 0 && (int)x > (int)y)
            {
                return 1;
            }
            else if ((int)x % 2 != 0 && (int)y % 2 != 0 && (int)x == (int)y)
            {
                return 0;
            }
            else if ((int)x % 2 == 0 && (int)y % 2 != 0)
            {
                return -1;
            }
            else if ((int)x % 2 != 0 && (int)y % 2 == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var sortEvenFirst = new SortEvenFirst();
            Array.Sort(input,0,input.Length,sortEvenFirst);
            foreach (var item in input)
            {
                Console.Write(item + " ");
            }
        }
    }
}
