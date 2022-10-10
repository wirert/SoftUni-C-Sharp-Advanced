using System.IO;

namespace CopyBinaryFile
{
    using System;
    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream inputFileStream = new FileStream(inputFilePath, FileMode.Open))
            {
                byte[] buffer = new byte[1024];

                using (FileStream outputStream = new FileStream(outputFilePath, FileMode.Create))
                {
                    while (true)
                    {
                        int bytesRead =  inputFileStream.Read(buffer, 0, buffer.Length);

                        if (bytesRead == 0)
                        {
                            break;
                        }

                        outputStream.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
