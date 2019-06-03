using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interface;
using Utilities;

namespace Extensibility
{
    public static class ReadCSV<T>
    {
        public static IEnumerable<T> ReadFile(FileInformation<T> fileInfo)
        {

            using (var reader = new StreamReader(fileInfo.FileLocation + fileInfo.FileName))
            {
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.HasHeaderRecord = fileInfo.HasHeader;

                    var records = csv.GetRecords<T>().ToList();

                    return records;
                }

            }

        }

    }

}
