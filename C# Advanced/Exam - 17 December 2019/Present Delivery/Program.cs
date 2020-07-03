using System;
using System.ComponentModel.Design;
using System.Dynamic;

namespace Present_Delivery
{
    class Program
    {
        private static int countOfPresents;
        private static int happyKids = 0;

        static void Main(string[] args)
        {
            var m = int.Parse(Console.ReadLine());
            countOfPresents = m;
            var n = int.Parse(Console.ReadLine());
            var matrix = new string[n, n];
            var santaPos = ReadMatrix(matrix);
            var santaRow = santaPos[0];
            var santaCol = santaPos[1];
            var command = Console.ReadLine();
            while (true)
            {
                if (command == "Christmas morning")
                {
                    break;
                }
                if (command == "up")
                {
                    matrix[santaRow, santaCol] = "-";
                    santaRow--;
                    CheckForCookie(matrix,santaRow,santaCol);
                    CheckForNice(matrix, santaRow, santaCol);
                    CheckForNaughty(matrix, santaRow, santaCol);
                    matrix[santaRow, santaCol] = "S";
                }
                else if (command == "down")
                {
                    matrix[santaRow, santaCol] = "-";
                    santaRow++;
                    CheckForCookie(matrix, santaRow, santaCol);
                    CheckForNice(matrix, santaRow, santaCol);
                    CheckForNaughty(matrix, santaRow, santaCol);
                    matrix[santaRow, santaCol] = "S";
                }
                else if (command == "left")
                {
                    matrix[santaRow, santaCol] = "-";
                    santaCol--;
                    CheckForCookie(matrix, santaRow, santaCol);
                    CheckForNice(matrix, santaRow, santaCol);
                    CheckForNaughty(matrix, santaRow, santaCol);
                    matrix[santaRow, santaCol] = "S";
                }
                else if (command == "right")
                {
                    matrix[santaRow, santaCol] = "-";
                    santaCol++;
                    CheckForCookie(matrix, santaRow, santaCol);
                    CheckForNice(matrix, santaRow, santaCol);
                    CheckForNaughty(matrix, santaRow, santaCol);
                    matrix[santaRow, santaCol] = "S";
                }
                if (countOfPresents == 0)
                {
                    Console.WriteLine("Santa ran out of presents!");
                    break;
                }
                command = Console.ReadLine();
            }
            PrintMatrix(matrix);
            var numberOfKids = GetUnhappy(matrix);
            if (numberOfKids > 0)
            {
                Console.WriteLine($"No presents for {numberOfKids} nice kid/s.");
            }
            else
            {
                Console.WriteLine($"Good job, Santa! {happyKids} happy nice kid/s.");
            }
        }

        private static int GetUnhappy(string[,] matrix)
        {
            var count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == "V")
                    {
                        count++;
                    }
                }

            }

            return count;
        }

        private static void CheckForNaughty(string[,] matrix, int santaRow, int santaCol)
        {
            if (matrix[santaRow,santaCol] == "X")
            {
                matrix[santaRow, santaCol] = "-";
            }
        }

        private static void CheckForNice(string[,] matrix, int santaRow, int santaCol)
        {
            if (matrix[santaRow,santaCol] == "V")
            {
                countOfPresents--;
                happyKids++;
                matrix[santaRow, santaCol] = "-";
            }
        }

        private static void CheckForCookie(string[,] matrix, int santaRow, int santaCol)
        {
            if (matrix[santaRow,santaCol] == "C")
            {
                CheckForAny(matrix,santaRow + 1,santaCol);
                CheckForAny(matrix,santaRow - 1,santaCol);
                CheckForAny(matrix,santaRow,santaCol + 1);
                CheckForAny(matrix,santaRow,santaCol - 1);
            }
        }

        private static void CheckForAny(string[,] matrix, in int santaRow, int santaCol)
        {
            if (matrix[santaRow, santaCol] == "V" || matrix[santaRow, santaCol] == "X")
            {
                countOfPresents--;
                happyKids++;
                matrix[santaRow, santaCol] = "-";
            }
        }

        private static int[] ReadMatrix(string[,] matrix)
        {
            var santaRow = -1;
            var santaCol = -1;
            var arr = new int[2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = Console.ReadLine().Split();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                    if (matrix[i,j] == "S")
                    {
                        arr[0] = i;
                        arr[1] = j;
                    }
                }
            }

            return arr;
        }
        private static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
