namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            DirectoryInfo folderInfo = new DirectoryInfo(folderPath);

            FileInfo[] filesInfo = folderInfo.GetFiles("*", SearchOption.AllDirectories);

            double size = 0;

            foreach (var file in filesInfo)
            {
                size += file.Length;
            }

            size = size / 1024;

            File.WriteAllText(outputFilePath, size.ToString());
        }
    }
}