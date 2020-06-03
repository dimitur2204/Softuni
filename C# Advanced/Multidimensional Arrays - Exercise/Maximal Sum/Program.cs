using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = rowsAndCols[0];
            var cols = rowsAndCols[1];
            var matrix = new int[rows, cols];
            var maxSum = int.MinValue;
            var maxSquare = "";
            FillMatrix(matrix);
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    var sum = GetSquareSum(matrix, row, col);
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxSquare = GetCurrentSquare(matrix,row,col);
                    } 
                }
            }
            Console.WriteLine("Sum = " + maxSum);
            Console.WriteLine(maxSquare);
        }

        private static string GetCurrentSquare(int[,] matrix, int row, int col)
        {
            var result = "";
            for (int i = row; i < row + 3; i++)
            {
                for (int j = col; j < col + 3; j++)
                {
                    result += matrix[i, j] + " ";
                }
                result += "\n";
            }
            return result;
        }

        private static int GetSquareSum(int[,] matrix, int row, int col)
        {
            var sum = 0;
            for (int i = row; i < row + 3; i++)
            {
                for (int j = col; j < col + 3; j++)
                {
                    sum += matrix[i, j];
                }
            }
            return sum;
        }

        static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
