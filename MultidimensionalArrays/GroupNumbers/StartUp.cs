using System;
using System.Linq;

namespace GroupNumbers
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None).Select(int.Parse).ToArray();
            var sizes = new int[3];
            foreach (var number in numbers)
            {
                sizes[Math.Abs(number % 3)]++;
            }

            int[][] jaggedArr = new int[3][];
            for (int counter = 0; counter < sizes.Length; counter++)
            {
                jaggedArr[counter] = new int[sizes[counter]];
            }

            int[] index = new int[3];
            foreach (var number in numbers)
            {
                var reminder = Math.Abs(number % 3);
                jaggedArr[reminder][index[reminder]] = number;
                index[reminder]++;
            }

            for (int rows = 0; rows < jaggedArr.Length; rows++)
            {
                for (int columns = 0; columns < jaggedArr[rows].Length; columns++)
                {
                    Console.Write(jaggedArr[rows][columns]+" ");
                }

                Console.WriteLine();
            }
        }
    }
}
