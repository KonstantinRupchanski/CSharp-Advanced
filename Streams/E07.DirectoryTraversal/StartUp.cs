using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace E07.DirectoryTraversal
{
    public class StartUp
    {
        public static void Main()
        {
            string sourcePath = Console.ReadLine();
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filesDict = new Dictionary<string, Dictionary<string, long>>();

            var filesInDirectory = Directory.GetFiles(sourcePath, "*.*", SearchOption.TopDirectoryOnly);
            foreach (var file in filesInDirectory)
            {
                var fileInfo = new FileInfo(file);
                var extension = fileInfo.Extension;
                var name = fileInfo.Name;
                var length = fileInfo.Length;

                if (!filesDict.ContainsKey(extension))
                {
                    filesDict[extension] = new Dictionary<string, long>();
                }
                if (!filesDict[extension].ContainsKey(name))
                {
                    filesDict[extension][name] = length;
                }
            }

            var filesDictSorted = filesDict
                .OrderByDescending(x => x.Value.Count)  
                .ThenBy(x => x.Key);   
            
            using (var report = new StreamWriter($"{desktop}/report.txt"))
            {
                foreach (var kvp in filesDictSorted)
                {
                    var extension = kvp.Key;
                    var files = filesDict[extension].OrderByDescending(x => x.Value);

                    report.WriteLine(extension);
                    foreach (var file in files)
                    {
                        double fileSize = (double) file.Value / 1024;
                        report.WriteLine($"--{file.Key} - {fileSize:f3} kb");
                    }
                }
            }
        }
    }
}
