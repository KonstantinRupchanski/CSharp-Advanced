using System;
using System.Linq;

namespace L04.AddVAT
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(d=>d*1.2)
                .ToList();

            foreach (var num in numbers)
            {
                Console.WriteLine($"{num:f2}");
            }
        }
    }
}
