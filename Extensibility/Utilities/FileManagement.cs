using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class FileManagement
    {
        #region Methods
        public static IEnumerable<string> FilesToProcess(string path, string fileExtension)
        {

            IEnumerable<string> filesInFolder = Directory.GetFiles(path, "*." + fileExtension);


            return filesInFolder;
        }

        public static void BackupFile(string sourceFileName, string destinationFileName)
        {
            File.Copy(sourceFileName, destinationFileName);

        }

        public static void ShowFiles(IEnumerable<string> files)
        {

            foreach (var file in files)
            {
                Console.WriteLine(file);

            }
        }


        public static void ShowFilesWithInfo(List<FileInfoRecordCount> files)
        {

            foreach (var file in files)
            {

                Console.Write($"Name: {file.FileName} Count: {file.RecordCount}");

            }

        }

        #endregion

    }
}
