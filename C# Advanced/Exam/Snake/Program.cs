using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = int.Parse(Console.ReadLine());
            var matrix = new char[matrixSize, matrixSize];
            var snakeRow = -1;
            var snakeCol = -1;
            var foodEaten = 0;
            for (int i = 0; i < matrixSize; i++)
            {
                var row = Console.ReadLine();
                for (int j = 0; j < matrixSize; j++)
                {
                    if (row[j] == 'S')
                    {
                        snakeRow = i;
                        snakeCol = j;
                    }
                    matrix[i, j] = row[j];
                }
            }

            var command = Console.ReadLine();
            while (true)
            {
                if (command == "up")
                {
                    matrix[snakeRow, snakeCol] = '.';
                    if (snakeRow - 1 < 0)
                    {
                        Console.WriteLine("Game over!");
                        break;
                    }

                    snakeRow--;
                    if (CheckForBurrow(matrix, snakeRow, snakeCol))
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        var burrowRowCol = GetBurrowPos(matrix);
                        var burrowRow = burrowRowCol[0];
                        var burrowCol = burrowRowCol[1];
                        matrix[burrowRow, burrowCol] = 'S';
                        snakeRow = burrowRow;
                        snakeCol = burrowCol;
                    }
                    if (CheckForFood(matrix,snakeRow,snakeCol))
                    {
                        foodEaten++;
                    }
                    matrix[snakeRow, snakeCol] = 'S';
                    if (foodEaten == 10)
                    {
                        Console.WriteLine("You won! You fed the snake.");
                        break;
                    }
                    
                }
                else if (command == "down")
                {
                    matrix[snakeRow, snakeCol] = '.';
                    if (snakeRow + 1 >= matrix.GetLength(0))
                    {
                        Console.WriteLine("Game over!");
                        break;
                    }
                    snakeRow++;
                    if (CheckForBurrow(matrix, snakeRow, snakeCol))
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        var burrowRowCol = GetBurrowPos(matrix);
                        var burrowRow = burrowRowCol[0];
                        var burrowCol = burrowRowCol[1];
                        matrix[burrowRow, burrowCol] = 'S';
                        snakeRow = burrowRow;
                        snakeCol = burrowCol;
                    }
                    if (CheckForFood(matrix, snakeRow, snakeCol))
                    {
                        foodEaten++;
                    }
                    matrix[snakeRow, snakeCol] = 'S';
                    if (foodEaten == 10)
                    {
                        Console.WriteLine("You won! You fed the snake.");
                        break;
                    }
                    
                }
                else if (command == "left")
                {
                    matrix[snakeRow, snakeCol] = '.';
                    if (snakeCol - 1 < 0)
                    {
                        Console.WriteLine("Game over!");
                        break;
                    }
                    snakeCol--;
                    if (CheckForBurrow(matrix, snakeRow, snakeCol))
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        var burrowRowCol = GetBurrowPos(matrix);
                        var burrowRow = burrowRowCol[0];
                        var burrowCol = burrowRowCol[1];
                        matrix[burrowRow, burrowCol] = 'S';
                        snakeRow = burrowRow;
                        snakeCol = burrowCol;
                    }
                    if (CheckForFood(matrix, snakeRow, snakeCol))
                    {
                        foodEaten++;
                    }
                    matrix[snakeRow, snakeCol] = 'S';
                    if (foodEaten == 10)
                    {
                        Console.WriteLine("You won! You fed the snake.");
                        break;
                    }
                    
                }
                else if (command == "right")
                {
                    matrix[snakeRow, snakeCol] = '.';
                    if (snakeCol + 1 >= matrix.GetLength(0))
                    {
                        Console.WriteLine("Game over!");
                        break;
                    }
                    snakeCol++;
                    if (CheckForBurrow(matrix,snakeRow,snakeCol))
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        var burrowRowCol = GetBurrowPos(matrix);
                        var burrowRow = burrowRowCol[0];
                        var burrowCol = burrowRowCol[1];
                        matrix[burrowRow, burrowCol] = 'S';
                        snakeRow = burrowRow;
                        snakeCol = burrowCol;
                    }
                    if (CheckForFood(matrix, snakeRow, snakeCol))
                    {
                        foodEaten++;
                    }
                    matrix[snakeRow, snakeCol] = 'S';
                    if (foodEaten == 10)
                    {
                        Console.WriteLine("You won! You fed the snake.");
                        break;
                    }
                    
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Food eaten: {foodEaten}");
            PrintMatrix(matrix);
        }

        private static int[] GetBurrowPos(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == 'B')
                    {
                        return new int[2] {i,j};
                    }

                }
            }

            return null;
        }

        private static bool CheckForBurrow(char[,] matrix,  int snakeRow,  int snakeCol)
        {
            if (matrix[snakeRow, snakeCol] == 'B')
            {
                return true;
            }

            return false;
        }

        private static bool CheckForFood(char[,] matrix,  int snakeRow,  int snakeCol)
        {
            if (matrix[snakeRow,snakeCol] == '*')
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
