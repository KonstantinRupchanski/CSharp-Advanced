using System;
using System.IO;

namespace L01.ReadFile
{
    public class Program
    {
        public static void Main()
        {
            using (var stream = new StreamReader("Program.cs"))
            {
                var lineNumber = 1;
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    Console.WriteLine($"Line {lineNumber}: {line}");
                    lineNumber++;
                }
            }
        }
    }
}
