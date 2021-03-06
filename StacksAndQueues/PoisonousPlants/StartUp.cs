﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PoisonousPlants
{
    public class StartUp
    {
        public static void Main()
        {
            var plantsCount = int.Parse(Console.ReadLine());
            var plants = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var daysToDie = new int[plantsCount];
            var plantsLeft = new Stack<int>();
            plantsLeft.Push(0);

            for (int i = 1; i < plantsCount; i++)
            {
                var maxDaysToDie = 0;

                while (plantsLeft.Count != 0 && plants[plantsLeft.Peek()] >= plants[i])
                {
                    maxDaysToDie = Math.Max(maxDaysToDie, daysToDie[plantsLeft.Pop()]);
                }

                if (plantsLeft.Count != 0)
                {
                    daysToDie[i] = maxDaysToDie + 1;
                }
                plantsLeft.Push(i);
            }
            Console.WriteLine(daysToDie.Max());
        }
    }
}
