using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int x = dimestions[0];
            int y = dimestions[1];
            int[,] matrix = new int[x, y];

            CreateMatrix(matrix, x, y);
            string command = Console.ReadLine();
            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] ivoS = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int[] evil = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int xE = evil[0];
                int yE = evil[1];

                matrix = EvilVectorMvmt(matrix, xE, yE);

                int xI = ivoS[0];
                int yI = ivoS[1];

                sum = IvoVectorSum(matrix, xI, yI);

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }
        static public long IvoVectorSum(int[,] matrix, int x, int y)
        {
            long sum = 0;
            while (x >= 0 && y < matrix.GetLength(1))
            {
                if (x >= 0 && y < matrix.GetLength(0) && y >= 0 && y < matrix.GetLength(1))
                {
                    sum += matrix[x, y];
                }

                y++;
                x--;
            }
            return sum;
        }
        static public int[,] EvilVectorMvmt(int[,] matrix, int x, int y) 
        {
            while (x >= 0 && y >= 0)
            {
                if (x >= 0 && x < matrix.GetLength(0) &&
                    y >= 0 && y < matrix.GetLength(1))
                {
                    matrix[x, y] = 0;
                }
                x--;
                y--;
            }
            return matrix;
        }
        static public void CreateMatrix(int[,] matrix, int x, int y) 
        {
            int value = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }
        }
    }
}
