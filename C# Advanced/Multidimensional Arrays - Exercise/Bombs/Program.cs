using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            var bombIndexes = Console.ReadLine().Split();
            foreach (var indexes in bombIndexes)
            {
                var bombRowCol = indexes.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var bombRow = bombRowCol[0];
                var bombCol = bombRowCol[1];
                if (matrix[bombRow,bombCol] > 0)
                {
                    Explode(matrix, bombRow, bombCol);
                }
            }
            var aliveCells = 0;
            var sumOfAliveCells = 0;
            foreach (var item in matrix)
            {
                if (item > 0)
                {
                    aliveCells++;
                    sumOfAliveCells += item;
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumOfAliveCells}");
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
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
//8 -4 -5 -2
//6 -3 7 2
//9 2 -4 -1
//6 8 1 2
        private static void Explode(int[,] matrix, int bombRow, int bombCol)
        {
            var bombValue = matrix[bombRow, bombCol];
            matrix[bombRow, bombCol] = 0;
            if (bombRow - 1 >= 0)
            {
                if (matrix[bombRow - 1, bombCol] > 0)
                {
                    matrix[bombRow - 1, bombCol] -= bombValue;
                }
                
                if (bombCol + 1 < matrix.GetLength(0) && matrix[bombRow - 1, bombCol + 1] > 0)
                {
                    matrix[bombRow - 1, bombCol + 1] -= bombValue;
                }

                if (bombCol - 1 >= 0 && matrix[bombRow - 1, bombCol - 1] > 0)
                {
                    matrix[bombRow - 1, bombCol - 1] -= bombValue;
                }
            }
            if (bombRow + 1 < matrix.GetLength(0))
            {
                if (matrix[bombRow + 1, bombCol] > 0)
                {
                    matrix[bombRow + 1, bombCol] -= bombValue;
                }
                
                if (bombCol + 1 < matrix.GetLength(0) && matrix[bombRow + 1, bombCol + 1] > 0)
                {
                    matrix[bombRow + 1, bombCol + 1] -= bombValue;
                }

                if (bombCol - 1 >= 0 && matrix[bombRow + 1, bombCol - 1] > 0)
                {
                    matrix[bombRow + 1, bombCol - 1] -= bombValue;
                }
                
            }
            if (bombCol + 1 < matrix.GetLength(0) && matrix[bombRow, bombCol + 1] > 0)
            {
                matrix[bombRow, bombCol + 1] -= bombValue;
            }
            if (bombCol - 1 >= 0 && matrix[bombRow, bombCol - 1] > 0)
            {
                matrix[bombRow, bombCol - 1] -= bombValue;
            }
        }
    }
}
