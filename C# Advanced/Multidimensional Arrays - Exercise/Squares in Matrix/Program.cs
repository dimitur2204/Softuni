using System;
using System.Linq;

namespace Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = rowsAndCols[0];
            var cols = rowsAndCols[1];
            var matrix = new string[rows, cols];
            var equalSquaresCount = 0;
            FillMatrix(matrix,rows,cols);
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    var element = matrix[row, col];
                    if (element == matrix[row+1,col]&&
                        element == matrix[row,col+1]&&
                        element == matrix[row+1,col+1])
                    {
                        equalSquaresCount++;
                    }
                }
            }
            Console.WriteLine(equalSquaresCount);
        }
        static void FillMatrix(string[,] matrix, int rows,int cols) 
        {
            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().Split();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
