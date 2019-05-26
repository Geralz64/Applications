using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensibility;
namespace Repository.FixedLengthFile
{
    public class ReadFixedLength<T>
    {

        public static List<string> ReadFixedLengthFile(FileInformation<T> fileInformation) {

            var records = new List<string>();
            
            using(var reader = new StreamReader(fileInformation.FileLocation + fileInformation.FileName))
            {
                reader.ReadToEnd();

                foreach (var record in reader.ToString())
                {
                    records.Add(record.ToString());
                    
                }
            }

            return records;
        }

        public static List<string> GetRecordInformationByPosition(FileInformation<T> fileInformation, List<Layout> layout)
        {

            var records = fileInformation.Records;

            var segments = new List<string>();

            foreach (var line in records)
            {
                int start = 0;
                int length = 0;

                foreach (var lenghtOfRecord in layout)
                {

                    length = lenghtOfRecord.LengthOfRecord;
                    string segment = line.ToString().Substring(start, length);

                    segments.Add(segment);

                    start = length;
                }
            }

            return segments;

        }




    }
}
