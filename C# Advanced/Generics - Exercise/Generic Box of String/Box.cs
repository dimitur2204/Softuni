
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace GenericBox
{
    public class Box<T>
    {
        public Box(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public static void Swap(List<Box<T>> list, int firstIndex, int secondIndex)
        {
            var temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }

        public static int CompareString(List<Box<string>> list, string elementToCompare)
        {
            var count = 0;
            foreach (var box in list)
            {
                if (box.Value.CompareTo(elementToCompare) == 1)
                {
                    count++;
                }
            }
            return count;
        }
        public static int CompareDouble(List<Box<double>> list, double elementToCompare)
        {
            var count = 0;
            foreach (var box in list)
            {
                if (box.Value > elementToCompare)
                {
                    count++;
                }
            }
            return count;
        }
        public override string ToString()
        {
            return $"{this.Value.GetType()}: {this.Value}";
        }
    }
}
