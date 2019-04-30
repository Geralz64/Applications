using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
namespace Utilities
{
    public class CSVFile<T>
    {

        public string FileName { get; set; }
        public string FileLocation { get; set; }
        public bool HasHeader { get; set; }
        public string Delimiter { get; set; }

        public List<T> Items { get; set; }

        public static IEnumerable<T> ReadCSVFile(CSVFile<T> csvFile)
        {


            using (var reader = new StreamReader(csvFile.FileLocation + csvFile.FileName))
            {
                using (var csv = new CsvReader(reader))
                {

                    csv.Configuration.HasHeaderRecord = csvFile.HasHeader;
                    var member = csv.GetRecords<T>().ToList();

                    return member;
                }

            }

        }

        public void CreateCSVFile(CSVFile<T> file)
        {
            string fileFullPath = file.FileLocation + file.FileName;

            using (var writer = new StreamWriter(fileFullPath))
            {
                using (var csv = new CsvWriter(writer))
                {
                    csv.Configuration.HasHeaderRecord = file.HasHeader;
                    csv.Configuration.Delimiter = file.Delimiter;

                    csv.WriteRecords(file.Items);
                }
            }
        }


    }
}
