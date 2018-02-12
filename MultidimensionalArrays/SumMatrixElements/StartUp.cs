using System;
using System.Linq;

namespace SumMatrixElements
{
    public class StartUp
    {
        public static void Main()
        {
            int[] rowsAndColums = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None).Select(int.Parse).ToArray();
            int[,] matrix = new int[rowsAndColums[0],rowsAndColums[1]];
            for (int rows = 0; rows < rowsAndColums[0]; rows++)
            {
                var rowValues = Console.ReadLine().Split(new string[]{", "},StringSplitOptions.None).Select(int.Parse).ToArray();
                for (int colums = 0; colums < rowsAndColums[1]; colums++)
                {
                    matrix[rows, colums] = rowValues[colums];
                }
            }

            int sum = 0;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int colums = 0; colums < matrix.GetLength(1); colums++)
                {
                    sum += matrix[rows, colums];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
