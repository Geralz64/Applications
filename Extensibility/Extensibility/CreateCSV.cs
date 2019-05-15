using System.IO;

namespace Extensibility
{
    public static class CreateCSV<T>
    {
        public static void CreateCSVFile(CSVFileInformation<T> cSVFileInformation)
        {

            using (var writer = new StreamWriter(cSVFileInformation.FileLocation + cSVFileInformation.FileName, true))
            {

                foreach (var line in cSVFileInformation.Records)
                {
                    writer.WriteLine(line);
                }
                writer.Close();
            };

        }

    }
}
