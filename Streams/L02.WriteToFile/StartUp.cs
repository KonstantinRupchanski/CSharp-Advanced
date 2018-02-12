using System;
using System.IO;

namespace L02.WriteToFile
{
    public class StartUp
    {
        public static void Main()
        {
            using (var readStream = new StreamReader("StartUp.cs"))
            {
                using (var writeStream = new StreamWriter("reversed.txt"))
                {
                    string line;
                    while ((line = readStream.ReadLine()) != null)
                    {
                        for (int counter = line.Length - 1; counter >= 0; counter--)
                        {
                            writeStream.Write(line[counter]);
                        }
                        writeStream.WriteLine();
                    }
                }
            }
        }
    }
}
