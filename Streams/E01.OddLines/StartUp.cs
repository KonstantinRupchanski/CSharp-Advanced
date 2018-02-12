using System;
using System.IO;

namespace E01.OddLines
{
    public class StartUp
    {
        public static void Main()
        {
            using (var text = new StreamReader("../Resources/text.txt"))
            {
                int lineNumber = 0;
                string line;

                while ((line = text.ReadLine())!=null)
                {

                    if (lineNumber%2!=0)
                    {
                        Console.WriteLine(line);
                    }

                    lineNumber++;
                }
            }
        }
    }
}
