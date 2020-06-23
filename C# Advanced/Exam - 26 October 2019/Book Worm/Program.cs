using System;
using System.Linq;
using System.Text;

namespace Book_Worm
{
    class Program
    {
        static void Main(string[] args)
        {
            var initString = new StringBuilder(Console.ReadLine());
            var size = int.Parse(Console.ReadLine());
            var matrix = new char[size,size];
            var playerRow = -1;
            var playerCol = - 1;
            //ReadMatrix
            for (int i = 0; i < size; i++)
            {
                var row = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    if (row[j] == 'P')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                    matrix[i, j] = row[j];
                }
            }

            var command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "up")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerRow--;
                    if (!CheckForPunishment(matrix,playerRow,playerCol,initString))
                    {
                        CheckForLetter(matrix,playerRow,playerCol,initString);
                        matrix[playerRow, playerCol] = 'P';
                    }
                    else
                    {
                        matrix[playerRow + 1, playerCol] = 'P';
                        playerRow++;
                    }
                }
                else if (command == "down")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerRow++;
                    if (!CheckForPunishment(matrix, playerRow, playerCol, initString))
                    {
                        CheckForLetter(matrix, playerRow, playerCol, initString);
                        matrix[playerRow, playerCol] = 'P';
                    }
                    else
                    {
                        matrix[playerRow - 1, playerCol] = 'P';
                        playerRow--;
                    }
                }
                else if (command == "left")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerCol--;
                    if (!CheckForPunishment(matrix, playerRow, playerCol, initString))
                    {
                        CheckForLetter(matrix, playerRow, playerCol, initString);
                        matrix[playerRow, playerCol] = 'P';
                    }
                    else
                    {
                        matrix[playerRow, playerCol + 1] = 'P';
                        playerCol++;
                    }
                }
                else if (command == "right")
                {
                    matrix[playerRow, playerCol] = '-';
                    playerCol++;
                    if (!CheckForPunishment(matrix, playerRow, playerCol, initString))
                    {
                        CheckForLetter(matrix, playerRow, playerCol, initString);
                        matrix[playerRow, playerCol] = 'P';
                    }
                    else
                    {
                        matrix[playerRow, playerCol - 1] = 'P';
                        playerCol--;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(initString);
            PrintMatrix(matrix);
        }

        private static void CheckForLetter(char[,] matrix, in int playerRow, in int playerCol, StringBuilder initString)
        {
            if (Char.IsLetter(matrix[playerRow,playerCol]))
            {
                initString.Append(matrix[playerRow, playerCol]);
            }
        }

        private static bool CheckForPunishment(char[,] matrix, int playerRow, int playerCol, StringBuilder initString)
        {
            try
            {
                var checkValue = matrix[playerRow, playerCol];
                return false;
            }
            catch (Exception e)
            {
                initString.Remove(initString.Length - 1, 1);
                return true;
            }
        }
        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
