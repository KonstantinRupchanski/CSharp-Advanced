using System;
using System.IO;
using System.Text;

namespace L05.WriteInMemoryStream
{
    public class StartUp
    {
        public static void Main()
        {
            var text = "1t";
            var bytes = Encoding.UTF8.GetBytes(text);
            using (var stream = new MemoryStream(bytes))
            {
                int oneByte;
                while ((oneByte = stream.ReadByte())!=-1)
                {
                    var character = (char) oneByte;
                    Console.Write(character);
                }
            }
        }
    }
}
