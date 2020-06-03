using System;
using System.Linq;

namespace Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = dimensions[0];
            var m = dimensions[1];
            var matrix = new char[n, m];
            var playerRow = -1;
            var playerCol = -1;
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
            var commands = Console.ReadLine().ToCharArray();
            foreach (var command in commands)
            {
                if (command == 'U')
                {
                    SpreadBunnies(matrix);
                    PrintMatrix(matrix);
                    if (CheckForLoseWithBunny(matrix))
                    {
                        PrintMatrix(matrix);
                        Console.WriteLine($"dead: {playerRow} {playerCol}");
                        return;
                    }
                    if (CheckWinUp(matrix, playerRow, playerCol))
                    {
                        PrintMatrix(matrix);
                        Console.WriteLine($"won: {playerRow} {playerCol}");
                        return;
                    }
                    if (CheckForLoseWithRunningUp(matrix, playerRow, playerCol))
                    {
                        PrintMatrix(matrix);
                        Console.WriteLine($"dead: {playerRow} {playerCol}");
                        return;
                    }
                    MoveUp(matrix, playerRow, playerCol);
                    playerRow--;
                }
                else if (command == 'D')
                {
                    SpreadBunnies(matrix);
                    if (CheckForLoseWithBunny(matrix))
                    {
                        PrintMatrix(matrix);
                        Console.WriteLine($"dead: {playerRow} {playerCol}");
                        return;
                    }
                    if (CheckWinDown(matrix, playerRow, playerCol))
                    {
                        PrintMatrix(matrix);
                        Console.WriteLine($"won: {playerRow} {playerCol}");
                        return;
                    }
                    if (CheckForLoseWithRunningDown(matrix, playerRow, playerCol))
                    {
                        PrintMatrix(matrix);
                        Console.WriteLine($"dead: {playerRow} {playerCol}");
                        return;
                    }
                    MoveDown(matrix, playerRow, playerCol);
                    playerRow++;
                }
                else if (command == 'L')
                {
                    SpreadBunnies(matrix);
                    PrintMatrix(matrix);
                    if (CheckForLoseWithBunny(matrix))
                    {
                        PrintMatrix(matrix);
                        Console.WriteLine($"dead: {playerRow} {playerCol}");
                        return;
                    }
                    if (CheckWinLeft(matrix, playerRow, playerCol))
                    {
                        PrintMatrix(matrix);
                        Console.WriteLine($"won: {playerRow} {playerCol}");
                        return;
                    }
                    if (CheckForLoseWithRunningLeft(matrix, playerRow, playerCol))
                    {
                        PrintMatrix(matrix);
                        Console.WriteLine($"dead: {playerRow} {playerCol}");
                        return;
                    }
                    MoveLeft(matrix, playerRow, playerCol);
                    playerCol--;
                }
                else if (command == 'R')
                {
                    SpreadBunnies(matrix);
                    if (CheckForLoseWithBunny(matrix))
                    {
                        PrintMatrix(matrix);
                        Console.WriteLine($"dead: {playerRow} {playerCol}");
                        return;
                    }
                    if (CheckWinRight(matrix, playerRow, playerCol))
                    {
                        PrintMatrix(matrix);
                        Console.WriteLine($"won: {playerRow} {playerCol}");
                        return;
                    }
                    if (CheckForLoseWithRunningRight(matrix, playerRow, playerCol))
                    {
                        PrintMatrix(matrix);
                        Console.WriteLine($"dead: {playerRow} {playerCol}");
                        return;
                    }
                    MoveRight(matrix, playerRow, playerCol);
                    playerCol++;
                }
            }


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

        private static void MoveRight(char[,] matrix, int playerRow, int playerCol)
        {
            matrix[playerRow, playerCol] = '.';
            matrix[playerRow + 1, playerCol] = 'P';
        }

        private static bool CheckForLoseWithRunningRight(char[,] matrix, int playerRow, int playerCol)
        {
            return matrix[playerRow, playerCol + 1] == 'B';
        }

        private static bool CheckWinRight(char[,] matrix, int playerRow, int playerCol)
        {
            return playerCol + 1 < 0;
        }

        private static void MoveLeft(char[,] matrix, int playerRow, int playerCol)
        {
            matrix[playerRow, playerCol] = '.';
            matrix[playerRow - 1, playerCol] = 'P';
        }

        private static bool CheckForLoseWithRunningLeft(char[,] matrix, int playerRow, int playerCol)
        {
            return matrix[playerRow, playerCol - 1] == 'B';
        }

        private static bool CheckWinLeft(char[,] matrix, int playerRow, int playerCol)
        {
            return playerCol - 1 < 0;
        }

        private static void MoveDown(char[,] matrix, int playerRow, int playerCol)
        {
            matrix[playerRow, playerCol] = '.';
            matrix[playerRow + 1, playerCol] = 'P';
        }

        private static bool CheckForLoseWithRunningDown(char[,] matrix, int playerRow, int playerCol)
        {
            return matrix[playerRow + 1, playerCol] == 'B';
        }

        private static bool CheckWinDown(char[,] matrix, int playerRow, int playerCol)
        {
            return playerRow + 1 >= matrix.GetLength(0);
        }

        private static void MoveUp(char[,] matrix, int playerRow, int playerCol)
        {
            matrix[playerRow, playerCol] = '.';
            matrix[playerRow - 1, playerCol] = 'P';
        }

        private static bool CheckForLoseWithRunningUp(char[,] matrix, int playerRow, int playerCol)
        {
            return matrix[playerRow - 1, playerCol] == 'B';
        }

        private static bool CheckWinUp(char[,] matrix, int playerRow, int playerCol)
        {
            return playerRow - 1 < 0;
        }

        private static bool CheckForLoseWithBunny(char[,] matrix)
        {
            foreach (var item in matrix)
            {
                if (item == 'P')
                {
                    return false;
                }
            }
            return true;
        }

        private static void SpreadBunnies(char[,] matrix)
        {
            var matrixCopy = new char[matrix.GetLength(0),matrix.GetLength(1)];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrixCopy[row, col] = matrix[row, col];
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var element = matrix[row, col]; 
                    if (element == 'B')
                    {
                        if (row - 1 >= 0)
                        {
                            matrixCopy[row - 1, col] = 'B';
                        }
                        if (row + 1 < matrix.GetLength(0))
                        {
                            matrixCopy[row + 1, col] = 'B';
                        }
                        if (col - 1 >= 0)
                        {
                            matrixCopy[row, col - 1] = 'B';
                        }
                        if (col + 1 < matrix.GetLength(1))
                        {
                            matrixCopy[row, col + 1] = 'B';
                        }
                    }
                }
            }
        }
    }
}
