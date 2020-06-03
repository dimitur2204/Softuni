using System;

namespace Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            var removedKnights = 0;
            while (true)
            {
                var maxAttackedKnightCounter = 0;
                var maxAttackedKnightRow = -1;
                var maxAttackedKnightCol = -1;
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (matrix[row,col] == 'K')
                        {
                            var currentAttackedKnightCounter = GetAttackedKnights(matrix, row, col);
                            if (currentAttackedKnightCounter > maxAttackedKnightCounter)
                            {
                                maxAttackedKnightCounter = currentAttackedKnightCounter;
                                maxAttackedKnightRow = row;
                                maxAttackedKnightCol = col;
                            }
                        }
                    }
                }
                if (maxAttackedKnightCounter == 0)
                {
                    break;
                }
                matrix[maxAttackedKnightRow, maxAttackedKnightCol] = '0';
                removedKnights++;
            }
            Console.WriteLine(removedKnights);
        }

        private static int GetAttackedKnights(char[,] matrix, int row, int col)
        {
            var n = matrix.GetLength(0);
            var counter = 0;
            //0K0K0
            //K000K
            //00K00
            //K000K
            //0K0K0
            if (row - 2 >= 0 && col - 1 >= 0 && matrix[row - 2, col - 1] == 'K')
            {
                counter++;
            }
            if (row - 2 >= 0 && col + 1 < n && matrix[row - 2, col + 1] == 'K')
            {
                counter++;

            }
            if (row - 1 >= 0 && col - 2 >= 0 && matrix[row - 1, col - 2] == 'K')
            {
                counter++;

            }
            if (row - 1 >= 0 && col + 2 < n && matrix[row - 1, col + 2] == 'K')
            {
                counter++;

            }
            //down
            if (row + 1 < n && col - 2 >= 0 && matrix[row + 1, col - 2] == 'K')
            {
                counter++;

            }
            if (row + 1 < n && col + 2 < n && matrix[row + 1, col + 2] == 'K')
            {
                counter++;

            }
            if (row + 2 < n && col - 1 >= 0 && matrix[row + 2, col - 1] == 'K')
            {
                counter++;

            }
            if (row + 2 < n && col + 1 < n && matrix[row + 2, col + 1] == 'K')
            {
                counter++;

            }
            return counter;
        }
    }
}
