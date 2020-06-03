using System;
using System.Linq;

namespace Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var array = new double[rows][];
            ReadArray(array);
            ManipulateArray(array);
            var command = Console.ReadLine();
            while (command != "End")
            {
                var tokens = command.Split();
                var row = long.Parse(tokens[1]);
                var col = long.Parse(tokens[2]);
                var value = double.Parse(tokens[3]);
                if (IsIndexValid(array,row,col))
                {
                    if (tokens[0] == "Add")
                    {
                        array[row][col] += value;
                    }
                    else if (tokens[0] == "Subtract")
                    {
                        array[row][col] -= value;
                    }
                }
                command = Console.ReadLine();
            }
            PrintArray(array);
        }

        private static void PrintArray(double[][] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsIndexValid(double[][] array, long row, long col)
        {
            if (array.GetLength(0) <= row || row < 0)
            {
                return false;
            }
            else
            {
                if (array[row].Length <= col || col < 0)
                {
                    return false;
                }
            }
            return true;
        }

        private static void ManipulateArray(double[][] array)
        {
            for (int row = 0; row < array.GetLength(0) - 1; row++)
            {
                if (array[row].Length == array[row + 1].Length)
                {
                    MultiplyRow(array, row);
                    MultiplyRow(array, row + 1);
                }
                else
                {
                    DivideRow(array, row);
                    DivideRow(array, row + 1);
                }
            }
        }

        private static void DivideRow(double[][] array, int row)
        {
            for (int col = 0; col < array[row].Length; col++)
            {
                array[row][col] /= 2;
            }
        }

        private static void MultiplyRow(double[][] array, int row)
        {
            for (int col = 0; col < array[row].Length; col++)
            {
                array[row][col] *= 2;
            }
        }

        private static void ReadArray(double[][] array)
        {
            for (int row = 0; row < array.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                array[row] = new double[input.Length];
                for (int col = 0; col < array[row].Length; col++)
                {
                    array[row][col] = input[col];
                }
            }
        }
    }
}
