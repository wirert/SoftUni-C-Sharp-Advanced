namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            StreamReader firstReader = new StreamReader(firstInputFilePath);
            StreamReader secondReader = new StreamReader(secondInputFilePath);
            StreamWriter outputWriter = new StreamWriter(outputFilePath);
            
            using (firstReader)
            {
                using (secondReader)
                {
                    string firstFileLine = firstReader.ReadLine();
                    string secondFileLine = secondReader.ReadLine();

                    using (outputWriter)
                    {
                        while (firstFileLine != null && secondFileLine != null)
                        {
                            if (firstFileLine != null)
                                outputWriter.WriteLine(firstFileLine);

                            if (secondFileLine != null)
                                outputWriter.WriteLine(secondFileLine);

                            firstFileLine = firstReader.ReadLine();
                            secondFileLine = secondReader.ReadLine();
                        }
                    }
                }
            }
        }
    }
}