namespace Multidimensional_Arrays___Exercise
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var matrix = new int[rows,rows];
            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < rows; col++)
                {
                    matrix[row,col] = input[col];
                }
            }
            var mainDiag = 0;
            var secondaryDiag = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        mainDiag += matrix[row,col];
                    }
                    else if (row == matrix.GetLength() - col)
                    {
                        secondaryDiag += matrix[row,col];
                    }
                }
            }
            Console.WriteLine(Math.Abs(mainDiag - secondaryDiag));
        }
    }
}
