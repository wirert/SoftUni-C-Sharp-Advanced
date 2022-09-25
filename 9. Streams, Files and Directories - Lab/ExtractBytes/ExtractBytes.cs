namespace ExtractBytes
{
    using System.Collections.Generic;
    using System;
    using System.IO;
    public class ExtractBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            List<byte> bytesToSeek = new List<byte>();

            using (StreamReader bytesReader = new StreamReader(bytesFilePath))
            {
                string line = null;

                while ((line = bytesReader.ReadLine()) != null)
                {
                    bytesToSeek.Add(byte.Parse(line));
                }
            }

            List<byte> binaryFileOccur = new List<byte>();

            using (FileStream image = new FileStream(binaryFilePath, FileMode.Open))
            {
                byte[] buffer = new byte[image.Length];

                image.Read(buffer, 0, buffer.Length);

                foreach (var member in buffer)
                {
                    if (bytesToSeek.Contains(member))
                    {
                        binaryFileOccur.Add(member);
                    }
                }
            }

            using (var output = new FileStream(outputPath, FileMode.Create))
            {
                output.Write(binaryFileOccur.ToArray(), 0, binaryFileOccur.Count);
            }
        }
    }
}