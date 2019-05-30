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

        public static IEnumerable<string> ReadFile(FileInformation<T> fileInformation) {

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


    }
}
