using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{
    using System;
    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(inputFolderPath);

            FileInfo[] files = dirInfo.GetFiles("*", SearchOption.TopDirectoryOnly);

            SortedDictionary<string, List<FileInfo>> extensionFiles = new SortedDictionary<string, List<FileInfo>>();

            foreach (var fileInfo in files)
            {
                if (!extensionFiles.ContainsKey(fileInfo.Extension))
                {
                    extensionFiles.Add(fileInfo.Extension, new List<FileInfo>());
                }

                extensionFiles[fileInfo.Extension].Add(fileInfo);
            }

            StringBuilder text = new StringBuilder();

            foreach (var extension in extensionFiles.OrderByDescending(e => e.Value.Count))
            {
                text.AppendLine(extension.Key);

                foreach (var file in extension.Value.OrderBy(f => f.Length))
                {
                    text.AppendLine($"--{file.Name} - {file.Length / 1024}kb");
                }
            }
            
            return text.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;

            File.WriteAllText(filePath, textContent);
        }
    }
}
