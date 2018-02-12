using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    public  class Program
    {
        public static void Main()
        {
            var numbers = new List<int> {1, 2, 3, 4, 5, 6};
            var evenNums = new List<int>();

            //foreach (var number in numbers)
            //{
            //    if (number%2==0)
            //    {
            //        evenNums.Add(number);
            //    }
            //}

            var newEvenNums = numbers.Where(n => n % 2 == 0).ToList();
        }
    }
}
