using System;
using System.IO;

namespace L03.WriteTextToFile
{
    public class StartUp
    {
        public static void Main()
        {
            string text = "Кирилица.";
            FileStream stream = null;

            try
            {
                stream = new FileStream("log.txt", FileMode.Create);
                var bytes = System.Text.Encoding.UTF8.GetBytes(text);
                stream.Write(bytes, 0, bytes.Length);
            }
            finally
            {
                stream.Close();
            }
        }
    }
}
