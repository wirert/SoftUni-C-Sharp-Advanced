namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            byte[] source = File.ReadAllBytes(sourceFilePath);
            byte[] partOneBuffer = source.Length % 2 == 0 ? new byte[source.Length / 2] : new byte[source.Length / 2 + 1];
            byte[] partTwoBuffer = new byte[source.Length / 2];

            for (int i = 0; i < source.Length; i++)
            {
                if (i < partOneBuffer.Length)
                {
                    partOneBuffer[i] = source[i];
                }
                else
                {
                    partTwoBuffer[i - partOneBuffer.Length] = source[i];
                }
            }

            using (FileStream partOne = new FileStream(partOneFilePath, FileMode.Create))
            {
                partOne.Write(partOneBuffer, 0, partOneBuffer.Length);
            }

            using (FileStream partTwo = new FileStream(partTwoFilePath, FileMode.Create))
            {
                partTwo.Write(partTwoBuffer, 0, partTwoBuffer.Length);
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream joinedFile = new FileStream(joinedFilePath, FileMode.Create))
            {
                using (FileStream part = new FileStream(partOneFilePath, FileMode.Open))
                {
                    byte[] buffer = new byte[partOneFilePath.Length];

                    part.Read(buffer);
                    joinedFile.Write(buffer);
                }

                using (FileStream part = new FileStream(partTwoFilePath, FileMode.Open))
                {
                    byte[] buffer = new byte[partTwoFilePath.Length];

                    part.Read(buffer);
                    joinedFile.Write(buffer);
                }
            }
           

        }
    }
}