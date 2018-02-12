using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem03
{
    public class StartUp
    {
        public static void Main()
        {
            //var patternOne = @"\[([^[\]])*\]|\{[^[\}]*\}";
            var pattern = @"\[([^[\]])*(?<digits>[0-9]*)\]|\{[^[\}]*(?(digits)[0-9]*)\}";
            var digitPattern = new Regex(@"(?<digits>[\d]{2})");

            var count = int.Parse(Console.ReadLine());
            var textToCheck = new List<string>();

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine();

                MatchCollection matches = (Regex.Matches(input, pattern));


                Console.WriteLine(string.Join(' ', matches));
                textToCheck.Add(input);

            }

            List<string> resultList = textToCheck.Where(f => digitPattern.IsMatch(f)).ToList();

            foreach (var res in resultList)
            {
                Console.WriteLine(res); 
            }

        }
    }
}