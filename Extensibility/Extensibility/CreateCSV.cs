using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensibility
{
    public static class CreateCSV<T>
    {
        public static void CreateFile(FileInformation<T> fileInfo)
        {

            string fileFullPath = fileInfo.FileLocation + fileInfo.FileName;

            using (var writer = new StreamWriter(fileFullPath))
            {
                using (var csv = new CsvWriter(writer))
                {
                    csv.Configuration.HasHeaderRecord = fileInfo.HasHeader;
                    csv.Configuration.Delimiter = fileInfo.Delimiter;

                    csv.WriteRecords(fileInfo.Records);
                }
            }
        }



    }
}
