using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Repository.FixedLengthFile
{
    public static class ReadFixedLength<T>
    {

        public static IEnumerable<string> ReadFile(FileInformation<T> fileInformation)
        {

            var records = new List<string>();

            foreach (var line in File.ReadLines(fileInformation.FileLocation + fileInformation.FileName))
            {
                records.Add(line);
            }
            return records;
        }


    }
}
