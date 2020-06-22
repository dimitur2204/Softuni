using System;
using System.Dynamic;

namespace Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = int.Parse(Console.ReadLine());
            var countOfCommands = int.Parse(Console.ReadLine());
            var matrix = new char[matrixSize,matrixSize];
            var playerRow = -1;
            var playerCol = -1;
            for (int i = 0; i < matrixSize; i++)
            {
                var row = Console.ReadLine();
                for (int j = 0; j < matrixSize; j++)
                {
                    if (row[j] == 'f')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                    matrix[i, j] = row[j];
                }
            }

            for (int i = 0; i < countOfCommands; i++)
            {
                var command = Console.ReadLine();
                if (command == "up")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerRow--;
                    if (playerRow < 0)
                    {
                        playerRow = matrix.GetLength(1) - 1;
                    }
                    if (CheckForTrap(matrix, playerRow, playerCol))
                    {
                        playerRow++;
                        if (playerRow == matrix.GetLength(1))
                        {
                            playerRow = 0;
                        }
                    }
                    if (CheckForBonus(matrix, playerRow, playerCol))
                    {
                        playerRow--;
                        if (playerRow < 0)
                        {
                            playerRow = matrix.GetLength(1) - 1;
                        }
                    }
                    if (CheckForWin(matrix, playerRow, playerCol))
                    {
                        Console.WriteLine("Player won!");
                        matrix[playerRow, playerCol] = 'f';
                        PrintMatrix(matrix);
                        return;
                    }
                    matrix[playerRow, playerCol] = 'f';
                }
                else if (command == "down")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerRow++;
                    if (playerRow == matrix.GetLength(1))
                    {
                        playerRow = 0;
                    }
                    if (CheckForTrap(matrix, playerRow, playerCol))
                    {
                        playerRow--;
                        if (playerRow == 0)
                        {
                            playerRow = matrix.GetLength(1) - 1;
                        }
                    }
                    if (CheckForBonus(matrix, playerRow, playerCol))
                    {
                        playerRow++;
                        if (playerRow == matrix.GetLength(1))
                        {
                            playerRow = 0;
                        }
                    }
                    if (CheckForWin(matrix, playerRow, playerCol))
                    {
                        Console.WriteLine("Player won!");
                        matrix[playerRow, playerCol] = 'f';
                        PrintMatrix(matrix);
                        
                        return;
                    }
                    matrix[playerRow, playerCol] = 'f';
                }
                else if (command == "left")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerCol--;
                    if (playerCol < 0)
                    {
                        playerCol = matrix.GetLength(1) - 1;
                    }
                    if (CheckForTrap(matrix, playerRow, playerCol))
                    {
                        playerCol++;
                        if (playerCol == matrix.GetLength(1))
                        {
                            playerCol = 0;
                        }
                    }
                    if (CheckForBonus(matrix, playerRow, playerCol))
                    {
                        playerCol--;
                        if (playerCol < 0)
                        {
                            playerCol = matrix.GetLength(1) - 1;
                        }
                    }
                    if (CheckForWin(matrix, playerRow, playerCol))
                    {
                        Console.WriteLine("Player won!");
                        matrix[playerRow, playerCol] = 'f';
                        PrintMatrix(matrix);
                        return;
                    }
                    matrix[playerRow, playerCol] = 'f';
                    
                }
                else if (command == "right")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerCol++;
                    if (playerCol == matrix.GetLength(1))
                    {
                        playerCol = 0;
                    }
                    if (CheckForTrap(matrix, playerRow, playerCol))
                    {
                        playerCol--;
                        if (playerCol == 0)
                        {
                            playerCol = matrix.GetLength(1) - 1;
                        }
                    }
                    if (CheckForBonus(matrix, playerRow, playerCol))
                    {
                        playerCol++;
                        if (playerCol == matrix.GetLength(1))
                        {
                            playerCol = 0;
                        }
                    }
                    if (CheckForWin(matrix, playerRow, playerCol))
                    {
                        Console.WriteLine("Player won!");
                        matrix[playerRow, playerCol] = 'f';
                        PrintMatrix(matrix);
                        return;
                    }
                    matrix[playerRow, playerCol] = 'f';
                }
            }
            Console.WriteLine("Player lost!");
            matrix[playerRow, playerCol] = 'f';
            PrintMatrix(matrix);
        }

        private static bool CheckForWin(char[,] matrix, int playerRow, int playerCol)
        {
            if (matrix[playerRow,playerCol] == 'F')
            {
                return true;
            }
            return false;
        }

        private static bool CheckForBonus(char[,] matrix, int playerRow, int playerCol)
        {
            if (matrix[playerRow,playerCol] == 'B')
            {
                return true;
            }

            return false;
        }

        private static bool CheckForTrap(char[,] matrix, int playerRow,  int playerCol)
        {
            if (matrix[playerRow, playerCol] == 'T')
            {
                return true;
            }

            return false;
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
