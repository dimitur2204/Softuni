using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = rowsAndCols[0];
            var cols = rowsAndCols[1];
            var matrix = new char[rows,cols];
            var snake = Console.ReadLine();
            var snakeCopy = new Queue<char>(snake);
            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (snakeCopy.Count == 0)
                        {
                            snakeCopy = new Queue<char>(snake);
                            matrix[row, col] = snakeCopy.Dequeue();
                        }
                        else
                        {
                            matrix[row, col] = snakeCopy.Dequeue();
                        }
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0 ; col--)
                    {
                        if (snakeCopy.Count == 0)
                        {
                            snakeCopy = new Queue<char>(snake);
                            matrix[row, col] = snakeCopy.Dequeue();
                        }
                        else
                        {
                            matrix[row, col] = snakeCopy.Dequeue();
                        }
                    }
                }
            }
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
