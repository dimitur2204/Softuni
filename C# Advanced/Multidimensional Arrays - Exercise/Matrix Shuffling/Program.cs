using System;
using System.Linq;

namespace Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndCols = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = rowsAndCols[0];
            var cols = rowsAndCols[1];
            var matrix = new string[rows, cols];
            FillMatrix(matrix,rows,cols);
            var command = Console.ReadLine();
            while (command != "END")
            {
                var tokens = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] != "swap" || tokens.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }
                else
                {
                    var row1 = int.Parse(tokens[1]);
                    var col1 = int.Parse(tokens[2]);
                    var row2 = int.Parse(tokens[3]);
                    var col2 = int.Parse(tokens[4]);
                    if (IsRowInMatrix(matrix,row1) && 
                        IsRowInMatrix(matrix,row2) && 
                        IsColInMatrix(matrix,col1) && 
                        IsColInMatrix(matrix,col2))
                    {
                        var temp = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temp;
                        PrintMatrix(matrix);
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        command = Console.ReadLine();
                        continue;
                    }
                }
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsRowInMatrix(string[,] matrix, int row)
        {
            if (matrix.GetLength(0) > row)
            {
                return true;
            }
            return false;
        }
        private static bool IsColInMatrix(string[,] matrix, int col)
        {
            if (matrix.GetLength(1) > col)
            {
                return true;
            }
            return false;
        }

        static void FillMatrix(string[,] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
