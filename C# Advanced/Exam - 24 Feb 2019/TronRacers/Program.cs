using System;

namespace TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var matrix = new char[size, size];
            var player1Row = -1;
            var player1Col = -1;
            var player2Row = -1;
            var player2Col = -1;
            //ReadMatrix
            for (int i = 0; i < size; i++)
            {
                var row = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    if (row[j] == 'f')
                    {
                        player1Row = i;
                        player1Col = j;
                    }

                    if (row[j] == 's')
                    {
                        player2Row = i;
                        player2Col = j;
                    }
                    matrix[i, j] = row[j];
                }
            }

            while (true)
            {
                var commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var firstMove = commands[0];
                var secondMove = commands[0];
                if (firstMove == "up")
                {
                    if (MoveUp(matrix, player1Col, player1Row, 'f'))
                    {
                        player1Row++;
                    }
                    else
                    {
                        //end
                        break;
                    }
                }
                else if (firstMove == "down")
                {
                    if (MoveDown(matrix, player1Col, player1Row, 'f'))
                    {
                        player1Row--;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (firstMove == "left")
                {
                    if (MoveLeft(matrix, player1Col, player1Row, 'f'))
                    {
                        player1Col--;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (firstMove == "right")
                {
                    if (MoveRight(matrix, player1Col, player1Row, 'f'))
                    {
                        player1Col++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (secondMove == "up")
                {
                    if (MoveUp(matrix, player2Col, player2Row, 'f'))
                    {
                        player2Row++;
                    }
                    else
                    {
                        //end
                        break;
                    }
                }
                else if (secondMove == "down")
                {
                    if (MoveDown(matrix, player1Col, player1Row, 'f'))
                    {
                        player2Row--;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (secondMove == "left")
                {
                    if (MoveLeft(matrix, player1Col, player1Row, 'f'))
                    {
                        player2Col--;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (secondMove == "right")
                {
                    if (MoveRight(matrix, player1Col, player1Row, 'f'))
                    {
                        player2Col++;
                    }
                    else
                    {
                        break;
                    }
                }
                PrintMatrix(matrix);
            }
            PrintMatrix(matrix);
        }

        private static bool MoveUp(char[,] matrix, int playerCol, int playerRow, char c)
        {
            matrix[playerRow, playerCol] = c;
            if (playerRow == 0)
            {
                playerRow = matrix.GetLength(0) - 1;
            }
            else
            {
                playerRow--;
            }
            if (CheckForCrash(matrix, playerCol, playerRow, c))
            {
                return false;
            }

            matrix[playerRow, playerCol] = c;
            return true;
        }
        private static bool MoveDown(char[,] matrix, int playerCol, int playerRow, char c)
        {
            matrix[playerRow, playerCol] = c;
            if (playerRow == matrix.GetLength(0) - 1)
            {
                playerRow = 0;
            }
            else
            {
                playerRow++;
            }
            if (CheckForCrash(matrix, playerCol, playerRow, c))
            {
                return false;
            }

            matrix[playerRow, playerCol] = c;
            return true;
        }
        private static bool MoveLeft(char[,] matrix, int playerCol, int playerRow, char c)
        {
            matrix[playerRow, playerCol] = c;
            if (playerCol == 0)
            {
                playerCol = matrix.GetLength(0) - 1;
            }
            else
            {
                playerCol--;
            }
            if (CheckForCrash(matrix, playerCol, playerRow, c))
            {
                return false;
            }

            matrix[playerRow, playerCol] = c;
            return true;
        }
        private static bool MoveRight(char[,] matrix, int playerCol, int playerRow, char c)
        {
            matrix[playerRow, playerCol] = c;
            if (playerCol == matrix.GetLength(0) - 1)
            {
                playerCol = 0;
            }
            else
            {
                playerCol++;
            }
            if (CheckForCrash(matrix, playerCol, playerRow, c))
            {
                return false;
            }

            matrix[playerRow, playerCol] = c;
            return true;
        }

        private static bool CheckForCrash(char[,] matrix, int playerCol, int playerRow, char c)
        {
            if (c == 'f')
            {
                if (matrix[playerRow, playerCol] == 's')
                {
                    return true;
                }

                return false;
            }

            if (matrix[playerRow, playerCol] == 'f')
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
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
