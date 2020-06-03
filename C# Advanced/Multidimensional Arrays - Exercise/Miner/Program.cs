using System;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var commands = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            var matrix = new char[n, n];
            var minerRow = -1;
            var minerCol = -1;
            var allCoals = 0;
            var collectedCoals = 0;
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().Split(' ');
                for (int col = 0; col < n; col++)
                {
                    matrix[row,col] = input[col].ToCharArray()[0];
                    if (matrix[row,col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                    if (matrix[row, col] == 'c')
                    {
                        allCoals++;
                    }
                }
            }
            foreach (var command in commands)
            {
                if (command == "up")
                {
                    if (minerRow - 1 >= 0)
                    {
                        minerRow--;
                        if (CheckForEnd(matrix, minerRow, minerCol))
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                        if (CheckForCoal(matrix, minerRow, minerCol))
                        {
                            collectedCoals++;
                        }
                        if (CheckForCollectedCoals(allCoals, collectedCoals))
                        {
                            Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                            return;
                        }
                        MoveUp(matrix, minerRow + 1, minerCol);
                    }
                }
                else if (command == "down")
                {
                    if (minerRow + 1 < matrix.GetLength(0))
                    {
                        minerRow++;
                        if (CheckForEnd(matrix, minerRow, minerCol))
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                        if (CheckForCoal(matrix, minerRow, minerCol))
                        {
                            collectedCoals++;
                        }
                        if (CheckForCollectedCoals(allCoals, collectedCoals))
                        {
                            Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                            return;
                        }
                        MoveDown(matrix, minerRow - 1, minerCol);
                    }
                }
                else if (command == "left")
                {
                    if (minerCol - 1 >= 0)
                    {
                        minerCol--;
                        if (CheckForEnd(matrix, minerRow, minerCol))
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                        if (CheckForCoal(matrix, minerRow, minerCol))
                        {
                            collectedCoals++;
                        }
                        if (CheckForCollectedCoals(allCoals, collectedCoals))
                        {
                            Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                            return;
                        }
                        MoveLeft(matrix, minerRow, minerCol + 1);
                    }
                }
                else if (command == "right")
                {
                    if (minerCol + 1 < matrix.GetLength(0))
                    {
                        minerCol++;
                        if (CheckForEnd(matrix, minerRow, minerCol))
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                        if (CheckForCoal(matrix, minerRow, minerCol))
                        {
                            collectedCoals++;
                        }
                        if (CheckForCollectedCoals(allCoals, collectedCoals))
                        {
                            Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                            return;
                        }
                        MoveRight(matrix, minerRow, minerCol - 1);
                    }
                }
            }
            Console.WriteLine($"{allCoals - collectedCoals} coals left. ({minerRow}, {minerCol})");
        }

        private static bool CheckForCollectedCoals(int allCoals, int collectedCoals)
        {
            return allCoals == collectedCoals;
        }

        private static bool CheckForCoal(char[,] matrix, int minerRow, int minerCol)
        {
            if (matrix[minerRow, minerCol] == 'c')
            {
                matrix[minerRow, minerCol] = 's';
                return true;
            }
            return false;
        }

        private static bool CheckForEnd(char[,] matrix, int minerRow, int minerCol)
        {
            return matrix[minerRow, minerCol] == 'e';
        }

        private static void MoveRight(char[,] matrix, int minerRow, int minerCol)
        {
            matrix[minerRow, minerCol] = '*';
            matrix[minerRow, minerCol + 1] = 's';
        }

        private static void MoveLeft(char[,] matrix, int minerRow, int minerCol)
        {
            matrix[minerRow, minerCol] = '*';
            matrix[minerRow, minerCol - 1] = 's';
        }

        private static void MoveDown(char[,] matrix, int minerRow, int minerCol)
        {
            matrix[minerRow, minerCol] = '*';
            matrix[minerRow + 1, minerCol] = 's';
        }

        private static void MoveUp(char[,] matrix, int minerRow, int minerCol)
        {
            matrix[minerRow, minerCol] = '*';
            matrix[minerRow - 1,minerCol] = 's';
        }
    }
}
