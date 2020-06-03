using System;
using System.Linq;

namespace Multidimensional_Arrays___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = rows;
            var matrix = new int[rows,cols];
            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row,col] = input[col];
                }
            }
            /*
                11 2 4
                4 5 6
                10 8 -12
             */
            var mainDiag = 0;
            var secondDiag = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        mainDiag+=matrix[row,col];
                    }
                    if (row == matrix.GetLength(1) - col - 1)
                    {
                        secondDiag += matrix[row, col];
                    }
                }
            }
            Console.WriteLine(Math.Abs(mainDiag - secondDiag));
        }
    }
}
