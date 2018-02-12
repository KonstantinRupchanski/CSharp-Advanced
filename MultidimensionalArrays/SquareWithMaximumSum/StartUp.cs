using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    public class StartUp
    {
        public static void Main()
        {
            int[] rowsAndColums = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None).Select(int.Parse).ToArray();
            int[,] matrix = new int[rowsAndColums[0], rowsAndColums[1]];
            for (int rows = 0; rows < rowsAndColums[0]; rows++)
            {
                var rowValues = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None).Select(int.Parse).ToArray();
                for (int colums = 0; colums < rowsAndColums[1]; colums++)
                {
                    matrix[rows, colums] = rowValues[colums];
                }
            }

            int sum = 0;
            int rowIndex = 0, columnIndex = 0;
            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int colums = 0; colums < matrix.GetLength(1) - 1; colums++)
                {
                    var tempSum = matrix[rows, colums] + matrix[rows, colums + 1] + matrix[rows + 1, colums] +
                                  matrix[rows + 1, colums + 1];
                    if (tempSum > sum)
                    {
                        sum = tempSum;
                        rowIndex = rows;
                        columnIndex = colums;
                    }
                }
            }

            Console.WriteLine(matrix[rowIndex, columnIndex] + " " + matrix[rowIndex, columnIndex + 1]);
            Console.WriteLine(matrix[rowIndex + 1, columnIndex] + " " + matrix[rowIndex + 1, columnIndex + 1]);
            Console.WriteLine(sum);
        }
    }
}
