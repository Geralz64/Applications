using System.IO;

namespace Extensibility
{
    public static class CreateGenericFile<T>
    {
        public static void CreateFile(FileInformation<T> fileInfo)
        {
            using (var writer = new StreamWriter(fileInfo.FileLocation + fileInfo.FileName, true))
            {

                foreach (var line in fileInfo.Records)
                {
                    writer.WriteLine(line);
                }
                writer.Close();
            };

        }

    }
}
